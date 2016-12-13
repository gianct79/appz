# diff-webapp
## A "diff tool" running on a web server

This tool is used to perform byte by byte comparison, much like the cmp utility on Unix.

## Build instructions

The tool is dependent on Java so, make sure you have a `JAVA_HOME` pointing to an existing Java SDK (minimum is 7) installation.

Once you downloaded the source code, go to the directory and issue the following command:

```bash
$ ./gradlew build
```

## Run instructions

To run the application:

```bash
$ ./gradlew run
```

A web server will be listening on `http://localhost:8080/` exposing the entry points below:

| Path                | Verb | Description  |
| ------------------- |:----:| -------------|
| /v1/diff/           | GET  | returns a list containing ids for diff tasks |
| /v1/diff/           | POST | creates a new diff task                      |
| /v1/diff/{id}/left  | PUT  | updates the left content for comparison      |
| /v1/diff/{id}/right | PUT  | updates the right content for comparison     |
| /v1/diff/{id}       | GET  | performs the diff comparison                 |

For left and right content uploads, use this JSON body:

```javascript
{ "content": "ZGVhREJlZWY=" }
```

Note: content must be in Base64 format.

## Test instructions

To run integration tests: this tests all application's endpoints: it will start the web server and issue HTTP requests:

```bash
$ ./gradlew integrationTest
```

The test results will be written to `./build/reports/tests`.

### More testing

A [Postman collection](./diff-webapp.postman.json) is available to test the server. It contains examples for all entrypoints and JSON bodies.

Enjoy!
