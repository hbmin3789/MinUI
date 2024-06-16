import WebSocket from "ws";

const initWebSocketServer = () => new WebSocket.Server({ port: 5002 });

export default initWebSocketServer;
