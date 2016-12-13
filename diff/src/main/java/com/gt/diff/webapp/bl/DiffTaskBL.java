package com.gt.diff.webapp.bl;

import com.gt.diff.webapp.model.DiffTask;
import com.gt.diff.webapp.model.DiffTaskItem;
import com.gt.diff.webapp.model.DiffTaskResult;
import com.gt.diff.webapp.web.AppException;

import javax.ws.rs.core.Response;
import java.util.Collection;
import java.util.HashMap;
import java.util.Map;

/**
 * The DiffTaskBL class serves as a persistence class. All DiffTasks are stored
 * on a internal map in memory (the contents are not saved when application finishes).
 *
 * The createTask method is synchronized to avoid race conditions while updating the map.
 */
public class DiffTaskBL {

    private static Map<Integer, DiffTask> diffTasks = new HashMap<>();

    /**
     * Creates a DiffTask task.
     *
     * @return the new id to be used on further API calls.
     */
    public synchronized DiffTask createTask() {

        int id = Math.max(0, diffTasks.size() + 1);
        DiffTask dt = new DiffTask(id);
        diffTasks.put(id, dt);

        return dt;
    }

    /**
     * Gets task ids list.
     *
     * @return the tasks ids.
     */
    public Collection<Integer> getTasks() {

        return diffTasks.keySet();
    }

    /**
     * Gets a specific DiffTask by its id.
     *
     * @param id the task id returned by createTask.
     * @return the task if id is found, null otherwise.
     */
    public DiffTask getTaskById(int id) {
        return diffTasks.get(id);
    }

    /**
     * Performs the content comparison.
     * @param dt a DiffTask containing left and right content.
     *
     * @return a DiffTaskResult containing the content comparison result.
     */
    public DiffTaskResult getDiff(DiffTask dt) throws AppException {

        DiffTaskResult result = new DiffTaskResult();

        if (dt == null) {
            throw new AppException(Response.Status.INTERNAL_SERVER_ERROR, "invalid diff task");
        } else if (dt.getLeft() == null || dt.getRight() == null) {
            throw new AppException(Response.Status.INTERNAL_SERVER_ERROR, "empty diff task");
        } else if (dt.getLeft().getContent().length() != dt.getRight().getContent().length()) {
            result.setResult("contents have different sizes");
        } else if (dt.getLeft().getHash().compareTo(dt.getRight().getHash()) == 0) {
            result.setResult("contents are equal");
        } else {
            result.setResult("contents are different");

            Base64Compare base64 = new Base64Compare();

            try {
                result.setDiffs(base64.compare(dt.getLeft().getContent(), dt.getRight().getContent()));
            } catch (Exception e) {
                throw new AppException(Response.Status.INTERNAL_SERVER_ERROR, e.getMessage());
            }
        }

        return result;
    }

    /**
     * Performs basic validation of DiffTaskItem
     * @param dti the DiffTaskItem object to be validated
     * @return true if content is valid Base64 format.
     *
     * @throws AppException: in case of null content or length not multiple of 4.
     */
    public boolean validateDiffTaskItem(final DiffTaskItem dti) throws AppException {
        if (dti == null || dti.getContent() == null) {
            throw new AppException(Response.Status.BAD_REQUEST, "invalid content specified");
        }

        if ((dti.getContent().length() % 4) != 0) {
            throw new AppException(Response.Status.BAD_REQUEST, "invalid base64 input");
        }

        return true;
    }
}
