import WebSocket from "ws";

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
            message: `${files.length}`,
          })
        );
        console.log(`file count : ${files.length}`);
        files.forEach((filePath) => {
          fs.readFile(filePath, (err, data) => {
            if (err) {
              console.error("파일 읽기 중 오류 발생:", err);
              ws.send(
                JSON.stringify({ error: "파일 읽기 중 오류가 발생했습니다." })
              );
              return;
            }

            ws.send(
              JSON.stringify({
                fileName: filePath,
                fileData: data.toString("base64"),
              })
            );
          });
        });
      }
    });
  });
};
