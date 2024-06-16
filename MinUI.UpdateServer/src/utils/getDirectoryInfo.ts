import fs from "fs";
import path from "path";

export const getFilesInDirectory = (dir: string): string[] => {
  try {
    const files = fs.readdirSync(dir);
    return files.map((file) => path.join(dir, file));
  } catch (err) {
    console.error(`Error reading directory ${dir}:`, err);
    return [];
  }
};
