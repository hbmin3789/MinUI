import { Request, Response, NextFunction, Router } from "express";
import path from "path";

const router = Router();
router.get(
  "/{version}",
  async (req: Request, res: Response, next: NextFunction) => {
    const file = path.join(__dirname, "files", "example.pdf");
    res.download(file, (err) => {
      if (err) {
        console.error("파일 다운로드 중 오류 발생:", err);
        res.status(500).send("파일 다운로드 중 오류가 발생했습니다.");
      }
    });
  }
);

export default router;
