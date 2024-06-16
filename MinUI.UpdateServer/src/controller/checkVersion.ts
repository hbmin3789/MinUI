import { Request, Response, NextFunction, Router } from "express";

const router = Router();
router.get("/", async (req: Request, res: Response, next: NextFunction) => {
  res.json({ version: "1.0" });
});

export default router;
