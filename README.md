# Lit3DRecn
 Scene> Lit3D シーンを実行

## 検証動画

下のカメラから３Dシーンを再構築し、上のカメラで光源位置を推定し、ライティングをリアルタイムにしています。

https://github.com/user-attachments/assets/f7272d55-ad92-4c96-890b-03e529e0490b

## 仕組み

### 光源推定
|カメラ|360度画像|光源マスク|結果|
|---|---|---|---|
|![image](https://github.com/user-attachments/assets/18f011ca-5914-447e-83a2-cda49ebdcc4e)|![image](https://github.com/user-attachments/assets/7b93d271-94ac-419d-baac-a7c5d903ceae)|![スクリーンショット 2025-02-11 220551](https://github.com/user-attachments/assets/69e28ed3-e252-4e20-b0f2-33aa880ad82b)|![スクリーンショット 2025-02-11 223140](https://github.com/user-attachments/assets/cc258f9f-cd30-4a14-850f-0a21472e105f)

上360度カメラの画像から、ピクセルの明るさで光源を判断し光源の方向を推定、Unity Directional Lightに適応



### 3D再構築
|カメラ|360度画像|フィルタ済み深度推定|結果|
|---|---|---|---|
|![image](https://github.com/user-attachments/assets/6a799a6c-339e-4bc4-a462-c61c24263eff)|![image](https://github.com/user-attachments/assets/7b93d271-94ac-419d-baac-a7c5d903ceae)|![image](https://github.com/user-attachments/assets/54389e90-a957-4b8c-8b94-a97dec9cf1a8)|![image](https://github.com/user-attachments/assets/39685b15-62c1-4f3e-ad00-2d2162cd2533)

下360度カメラの画像から、深度を推定、一定距離以内の各ピクセルをキューブ化し、３Dシーンを再構築





