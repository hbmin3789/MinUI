import express, { json } from "express";
import setController from "./setup/setController";
//import cors from "cors";
import bodyParser from "body-parser";
import fs from "fs";
import https from "https";
import initWebSocketServer from "./websocket";
import setWebSocket from "./setup/setWebsocket";

const app = express();
const port = 5001;

app.use(json());
app.use(bodyParser.json());
// app.use(
//   cors({
//     origin: [
//       "http://localhost:3000",
//       "http://localhost:3001",
//       "https://49.247.170.116",
//       "https://vote.hogam.net",
//       "https://hogam.net",
//       "https://vote-396005.web.app",
//     ],
//   })
// );

setController(app);

//로컬이면 http로 돌려도됨ㅇㅇ
if (process.env.ENV === "local" || true) {
  app.listen(port, () => console.log(`http server opened`));
  setWebSocket();
} else {
  const options = {
    key: fs.readFileSync("/etc/letsencrypt/live/hogam.net/privkey.pem"),
    cert: fs.readFileSync("/etc/letsencrypt/live/hogam.net/cert.pem"),
    ca: fs.readFileSync("/etc/letsencrypt/live/hogam.net/chain.pem"),
  };
  const server = https.createServer(options, app);
  server.listen(port, () => console.log(`https server opened`));
}
