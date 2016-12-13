package com.gt.diff.webapp.web;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.ext.ExceptionMapper;
import javax.ws.rs.ext.Provider;

@Provider
/**
 * This class maps an AppException to a JSON object containing the error message.
 */
public class AppExceptionMapper implements ExceptionMapper<AppException> {
    @Override
    public Response toResponse(AppException ex) {
        return Response.status(ex.getStatus())
                .entity(String.format("{\"message\":\"%s\"}", ex.getMessage()))
                .type(MediaType.APPLICATION_JSON)
                .build();
    }
}
