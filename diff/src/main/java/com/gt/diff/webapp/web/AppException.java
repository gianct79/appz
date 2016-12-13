package com.gt.diff.webapp.web;

import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.ws.rs.core.Response;

@Data
@EqualsAndHashCode(callSuper=false)
/**
 * Exception class used by the application. Its main use is to provide a description
 * of the error, along with a HTTP status code. Used by the AppExceptionMapper class.
 */
public class AppException extends Throwable {
    Response.Status status;
    String message;

    /**
     *
     * @param status HTTP status code
     * @param message A description of the error
     */
    public AppException(Response.Status status, String message) {
        this.status = status;
        this.message = message;
    }
}
