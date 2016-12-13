package com.gt.diff.webapp.web;

import org.eclipse.jetty.server.Server;
import org.eclipse.jetty.servlet.ErrorPageErrorHandler;
import org.eclipse.jetty.servlet.ServletContextHandler;
import org.eclipse.jetty.servlet.ServletHolder;
import org.glassfish.jersey.server.ResourceConfig;
import org.glassfish.jersey.servlet.ServletContainer;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.ws.rs.core.MediaType;
import java.io.IOException;

public class App {

    private static class ErrorHandler extends ErrorPageErrorHandler {
        @Override
        public void handle(String target, org.eclipse.jetty.server.Request baseRequest, HttpServletRequest req, HttpServletResponse resp) throws IOException {
            resp.getWriter().format("{\"message\":\"HTTP status %d\"}", resp.getStatus());
            resp.setContentType(MediaType.APPLICATION_JSON);
        }
    }

    static private Server server;

    static Server startServer() throws Exception {

        ResourceConfig config = new ResourceConfig();
        config.packages("com.gt.diff.webapp.web");

        ServletHolder servlet = new ServletHolder(new ServletContainer(config));
        server = new Server(8080);

        ServletContextHandler context = new ServletContextHandler(server, "/*");
        context.addServlet(servlet, "/*");

        context.setErrorHandler(new ErrorHandler());

        server.start();

        return server;
    }

    public static void main(String[] args) {

        try {
            startServer();
            server.join();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
