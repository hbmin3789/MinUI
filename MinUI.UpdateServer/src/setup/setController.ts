import { Express } from "express";
import checkVersionController from "../controller/checkVersion";
import downloadController from "../controller/download";

const setController = (app: Express) => {
  app.use("/version", checkVersionController);
  app.use("/download", downloadController);
};

export default setController;
