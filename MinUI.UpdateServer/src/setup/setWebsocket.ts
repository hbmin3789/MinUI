import initWebSocketServer from "../websocket";
import { initDownloadWebSocket } from "../websocket/download";

const setWebSocket = () => {
  const wss = initWebSocketServer();
  initDownloadWebSocket(wss);
};

export default setWebSocket;
