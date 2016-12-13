package com.gt.diff.webapp.bl;

import com.gt.diff.webapp.model.DiffTask;
import com.gt.diff.webapp.model.DiffTaskItem;
import com.gt.diff.webapp.model.DiffTaskResult;
import com.gt.diff.webapp.web.AppException;
import org.junit.Assert;
import org.junit.FixMethodOrder;
import org.junit.Test;
import org.junit.runners.MethodSorters;

import java.util.Collection;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class DiffTaskBLTest {

    private static DiffTaskBL diffTaskBL = new DiffTaskBL();

    @Test
    public void createTask() throws Exception {
        DiffTask dt = diffTaskBL.createTask();
        Assert.assertEquals(1, dt.getId());
    }

    @Test
    public void getTasks() throws Exception {
        Collection<Integer> tasks = diffTaskBL.getTasks();
        Assert.assertNotEquals(0, tasks.size());
    }

    @Test
    public void getTaskById() throws Exception {
        DiffTask dt = diffTaskBL.getTaskById(1);
        Assert.assertNotNull(dt);
    }

    @Test
    public void getNotFoundTaskById() throws Exception {
        DiffTask dt = diffTaskBL.getTaskById(9);
        Assert.assertNull(dt);
    }

    @Test(expected = AppException.class)
    public void getNullDiffTask() throws AppException {
        diffTaskBL.getDiff(null);
    }

    @Test(expected = AppException.class)
    public void getNullLeftDiffTask() throws AppException {
        DiffTask dt = new DiffTask();
        dt.setRight(new DiffTaskItem());
        diffTaskBL.getDiff(dt);
    }

    @Test(expected = AppException.class)
    public void getNullRightTask() throws AppException {
        DiffTask dt = new DiffTask();
        dt.setLeft(new DiffTaskItem());
        diffTaskBL.getDiff(dt);
    }

    @Test
    public void getDiffSameContent() throws AppException {
        DiffTask dt = new DiffTask();
        DiffTaskItem dti = new DiffTaskItem();
        dti.setContent("RG9vTQ==");
        dt.setLeft(dti);

        dti = new DiffTaskItem();
        dti.setContent("RG9vTQ==");
        dt.setRight(dti);

        DiffTaskResult dtr = diffTaskBL.getDiff(dt);
        Assert.assertEquals("contents are equal", dtr.getResult());
    }

    @Test
    public void getDiffSizeMismatch() throws AppException {
        DiffTask dt = new DiffTask();
        DiffTaskItem dti = new DiffTaskItem();
        dti.setContent("RG9vTQ==");
        dt.setLeft(dti);

        dti = new DiffTaskItem();
        dti.setContent("ZGVhZGJlZWY=");
        dt.setRight(dti);

        DiffTaskResult dtr = diffTaskBL.getDiff(dt);
        Assert.assertEquals("contents have different sizes", dtr.getResult());
    }

    @Test
    public void getDiffContentMismatch() throws AppException {
        DiffTask dt = new DiffTask();
        DiffTaskItem dtl = new DiffTaskItem();
        dtl.setContent("MDAwMTAyMDMwNDA1MDYwNzA4MDk=");
        dt.setLeft(dtl);

        DiffTaskItem dtr = new DiffTaskItem();
        dtr.setContent("MDAwMjA0MDYwODAxMDMwNTA3MDk=");
        dt.setRight(dtr);

        DiffTaskResult r = diffTaskBL.getDiff(dt);
        Assert.assertEquals("contents are different", r.getResult());
        Assert.assertEquals(8, r.getDiffs().size());
    }

    @Test(expected = AppException.class)
    public void validateNullDiffTaskItem() throws Exception, AppException {
        diffTaskBL.validateDiffTaskItem(null);
    }

    @Test(expected = AppException.class)
    public void validateInvalidDiffTaskItemSize() throws Exception, AppException {
        DiffTaskItem dti = new DiffTaskItem();
        dti.setContent("abc");
        diffTaskBL.validateDiffTaskItem(null);
    }

    @Test(expected = AppException.class)
    public void validateNullDiffTaskItemContent() throws Exception, AppException {
        DiffTaskItem dti = new DiffTaskItem();
        diffTaskBL.validateDiffTaskItem(dti);
    }

    @Test
    public void validateEmptyDiffTaskItem() throws Exception, AppException {
        DiffTaskItem dti = new DiffTaskItem();
        dti.setContent("");
        diffTaskBL.validateDiffTaskItem(dti);
    }


}