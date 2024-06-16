import WebSocket from "ws";
import path from "path";

import fs from "fs";
import { getVersionFiles } from "../release/getVersion";

export const initDownloadWebSocket = (wss: WebSocket.Server) => {
  wss.on("connection", (ws) => {
    console.log("클라이언트가 연결되었습니다.");

    ws.on("message", (_message) => {
      const message = Buffer.from(_message.toString(), "utf-8").toString();
      console.log("받은 메시지:", message);

      if (message === "download") {
        const files = getVersionFiles("1.0");
        ws.send(
          JSON.stringify({
            message: `file count:${files.length}`,
          })
        );
        console.log(`file count : ${files.length}`);
        files.forEach((filePath) => {
          const fileName = path.basename(filePath);
          const fileStream = fs.createReadStream(filePath, {
            encoding: "base64",
          });
          fileStream.on("data", (chunk) => {
            let start = 0;
            const chunkSize = 8192; // 8KB
            while (start < chunk.length) {
              const end = start + chunkSize;
              ws.send(
                JSON.stringify({ fileName, fileData: chunk.slice(start, end) })
              );
              start = end;
            }
          });

          fileStream.on("end", () => {
            ws.send(JSON.stringify({ fileName, message: "eof" }));
          });
          fileStream.on("error", () => {
            ws.send(JSON.stringify({ fileName, error: "error" }));
          });
        });
      }
    });
  });
};
