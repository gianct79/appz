package com.gt.diff.webapp.web;

import com.gt.diff.webapp.bl.DiffTaskBL;
import com.gt.diff.webapp.model.DiffTask;
import com.gt.diff.webapp.model.DiffTaskItem;
import com.gt.diff.webapp.model.DiffTaskResult;

import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

/**
 * The Diff resource exposed at /v1/diff/ path.
 * This resource contains all entry points used by the application.
 * <p>
 * All paths return a JSON object to the clients even in case of errors.
 */
@Path("/v1/diff")
public class DiffResource {

    private DiffTaskBL diffTaskBL = new DiffTaskBL();

    /**
     * A GET request on /v1/diff/ will return a list with all DiffTasks as application/json.
     *
     * @return A JSON with a list containing DiffTask ids.
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Response getDiffs() {

        return Response.status(Response.Status.OK).entity(diffTaskBL.getTasks()).build();
    }

    /**
     * A GET request on /v1/diff/<id> will perform the file diff operation.
     *
     * @param id created by POST call to /v1/diff/
     * @return A DiffTaskResult object containing the actual diff result or,
     * HTTP 404 error if the DiffTask id is not found.
     * HTTP 400 error if the DiffTask has empty contents.
     * @throws AppException if DiffTask not found.
     */
    @GET
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getDiff(@PathParam("id") final int id) throws AppException {
        DiffTask dt = diffTaskBL.getTaskById(id);
        if (dt != null) {
            DiffTaskResult dtr = diffTaskBL.getDiff(dt);
            return Response.status(Response.Status.OK).entity(dtr).build();
        } else {
            throw new AppException(Response.Status.NOT_FOUND, "diff task not found");
        }
    }

    /**
     * A POST request on /v1/diff/ will create a DiffTask object to perform diff operations.
     *
     * @return A @DiffTask object containing a new id to be used on further calls.
     */
    @POST
    @Produces(MediaType.APPLICATION_JSON)
    public Response createDiff() {

        return Response.status(Response.Status.CREATED).entity(diffTaskBL.createTask()).build();
    }

    /**
     * A PUT request on /v1/diff/<id>/(left | right) will upload the content to the DiffTask.
     *
     * @param id   created by POST call to /v1/diff/
     * @param side upload content to left or right side of comparison
     * @param dti  DiffTasItem object with content in Base64 format
     * @return An empty body with HTTP 200 in case of success or,
     * HTTP 404 if DiffTask is not found.
     * HTTP 400 if a side different from left or right is specified.
     * @throws AppException if DiffTask not found or,
     *                      if DiffTaskItem has invalid content.
     */
    @PUT
    @Path("/{id}/{side}")
    @Produces(MediaType.APPLICATION_JSON)
    @Consumes(MediaType.APPLICATION_JSON)
    public Response updateDiff(@PathParam("id") final int id, @PathParam("side") final String side, DiffTaskItem dti) throws AppException {

        DiffTask dt = diffTaskBL.getTaskById(id);
        if (dt == null) {
            throw new AppException(Response.Status.NOT_FOUND, "diff task not found");
        }

        diffTaskBL.validateDiffTaskItem(dti);

        switch (side) {
            case "left": {
                dt.setLeft(dti);
                return Response.status(Response.Status.OK).build();
            }
            case "right": {
                dt.setRight(dti);
                return Response.status(Response.Status.OK).build();
            }
            default: {
                throw new AppException(Response.Status.BAD_REQUEST, "invalid side specified");
            }
        }
    }
}
