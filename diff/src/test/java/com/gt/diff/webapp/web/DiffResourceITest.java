package com.gt.diff.webapp.web;

import com.gt.diff.webapp.model.DiffTask;
import com.gt.diff.webapp.model.DiffTaskItem;
import com.gt.diff.webapp.model.DiffTaskResult;
import org.eclipse.jetty.server.Server;
import org.junit.*;
import org.junit.runners.MethodSorters;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.Response;
import java.util.Collection;
import java.util.Map;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class DiffResourceITest {

    private static Server server;
    private static WebTarget target;

    @BeforeClass
    public static void setUp() throws Exception {
        server = App.startServer();

        Client c = ClientBuilder.newClient();
        target = c.target("http://localhost:8080/v1/diff/");
    }

    @AfterClass
    public static void tearDown() throws Exception {
        server.stop();
    }

    @Test
    public void A_getDiffListEmpty() throws Exception {
        Response resp = target.request().get();
        Collection taskIds = resp.readEntity(Collection.class);
        Assert.assertEquals(0, taskIds.size());
        Assert.assertEquals(200, resp.getStatus());
    }

    @Test
    public void B_getDiffNotFound() throws Exception {
        Response resp = target.path("1").request().get();
        Assert.assertEquals(404, resp.getStatus());
    }

    @Test
    public void C_createDiff() throws Exception {
        Response resp = target.request().post(null);
        DiffTask dt = resp.readEntity(DiffTask.class);
        Assert.assertEquals(1, dt.getId());
        Assert.assertEquals(201, resp.getStatus());
    }

    @Test
    public void D_getDiffListNotEmpty() throws Exception {
        Response resp = target.request().get();
        Collection taskIds = resp.readEntity(Collection.class);
        Assert.assertNotEquals(0, taskIds.size());
        Assert.assertEquals(200, resp.getStatus());
    }

    @Test
    public void E_updateDiffNotFound() throws Exception {
        DiffTaskItem dti = new DiffTaskItem();
        dti.setContent("RG9vTQ==");
        Response resp = target.path("99/left").request().put(Entity.json(dti));
        Assert.assertEquals(404, resp.getStatus());
    }

    @Test
    public void F_getDiffSameContent() throws Exception {
        DiffTaskItem dti = new DiffTaskItem();
        dti.setContent("RG9vTQ==");

        Response respL = target.path("1/left").request().put(Entity.json(dti));
        Assert.assertEquals(200, respL.getStatus());

        Response respR = target.path("1/right").request().put(Entity.json(dti));
        Assert.assertEquals(200, respR.getStatus());

        Response resp = target.path("1").request().get();
        DiffTaskResult dtr = resp.readEntity(DiffTaskResult.class);
        Assert.assertEquals("contents are equal", dtr.getResult());
        Assert.assertEquals(200, resp.getStatus());
    }

    @Test
    public void G_getDiffSizeMismatch() throws Exception {
        DiffTaskItem dti = new DiffTaskItem();

        dti.setContent("RG9vTQ==");
        Response respL = target.path("1/left").request().put(Entity.json(dti));
        Assert.assertEquals(200, respL.getStatus());

        dti.setContent("ZGVhZGJlZWY=");
        Response respR = target.path("1/right").request().put(Entity.json(dti));
        Assert.assertEquals(200, respR.getStatus());

        Response resp = target.path("1").request().get();
        DiffTaskResult dtr = resp.readEntity(DiffTaskResult.class);
        Assert.assertEquals("contents have different sizes", dtr.getResult());
        Assert.assertEquals(200, resp.getStatus());
    }

    @Test
    public void H_getDiffContentMismatch() throws Exception {
        DiffTaskItem dti = new DiffTaskItem();

        dti.setContent("ZGVhREJlZWY="); // deaDBeef
        Response respL = target.path("1/left").request().put(Entity.json(dti));
        Assert.assertEquals(200, respL.getStatus());

        dti.setContent("ZGVhZGJlZWY="); // deadbeef
        Response respR = target.path("1/right").request().put(Entity.json(dti));
        Assert.assertEquals(200, respR.getStatus());

        Response resp = target.path("1").request().get();
        DiffTaskResult dtr = resp.readEntity(DiffTaskResult.class);
        Assert.assertEquals("contents are different", dtr.getResult());
        Assert.assertNotNull(dtr.getDiffs());

        Map<Integer, Integer> r = dtr.getDiffs();

        Assert.assertEquals(1, r.size());
        Assert.assertEquals(200, resp.getStatus());
    }
}
