# Lit3DRecn
 

## 検証動画

https://github.com/user-attachments/assets/f7272d55-ad92-4c96-890b-03e529e0490b

## 仕組み
上360度カメラの画像から、ピクセルの明るさで光源を判断し光源の方向を推定、Unity Directional Lightに適応

|カメラ|360度画像|光源マスク|結果|
|---|---|---|---|
|![image](https://github.com/user-attachments/assets/18f011ca-5914-447e-83a2-cda49ebdcc4e)|[![スクリーンショット 2025-01-05 122644](https://github.com/user-attachments/assets/28eaf3aa-78ef-411a-b27f-b45486394122)](https://scrapbox.io/files/676ba270153c59c6f70bc59a.png)|![スクリーンショット 2025-02-11 220551](https://github.com/user-attachments/assets/69e28ed3-e252-4e20-b0f2-33aa880ad82b)|![スクリーンショット 2025-02-11 222823](https://github.com/user-attachments/assets/11c406b0-e315-4122-8317-a163ee7d4ee4)


下360度カメラの画像から、深度を推定、一定距離以内の各ピクセルをキューブ化し、３Dシーンを再構築

![image](https://github.com/user-attachments/assets/a7dbab2c-b233-44f8-909a-201e5cbf8595)



