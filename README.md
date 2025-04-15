# Lit3DRecn
## 概要
360度カメラ映像から光源位置と、深度を推定し、現実の光源環境と3D幾何環境をリアルタイムでCG上に再構築する。　再構築した3Dシーンを立体ディスプレイで出力し、AIRRシステムにより空中像にすることで、よりリアルな空中像を再現できる。


Unity version 6000.0.28f1

## 実行方法

 Scene> Lit3D シーンを実行

注
MIDAS　AI モデルを使用するため Dpt_swin2_large_384.sentis のダウンロードが必要です。　Assets/StreamingAssetsにダウンロードファイルを入れてください。
 
 　ダウンロードページ　　https://huggingface.co/julienkay/sentis-MiDaS/tree/main/sentis
## 検証動画

下のカメラから３Dシーンを再構築し、上のカメラで光源位置を推定し、ライティングをリアルタイムにしています。

https://github.com/user-attachments/assets/f7272d55-ad92-4c96-890b-03e529e0490b

## 360度画像による結果

https://github.com/user-attachments/assets/5059c4f2-1aa0-49f2-9144-3d6c23f7c8be




## 仕組み

## 光源推定
参照論文

T. Rhee, L. Petikam, B. Allen and A. Chalmers, "MR360: Mixed Reality Rendering for 360° Panoramic Videos," in IEEE Transactions on Visualization and Computer Graphics, vol. 23, no. 4, pp. 1379-1388, April 2017
#### テストシーン
　　Assets/DebugLit/LitOnly.unity

#### 関連ソースコード
　　Assets/DebugLit/Lit.cs      
      
##### 実行結果
　　![image](https://github.com/user-attachments/assets/2510d470-7598-4b9a-953a-56592713eaf2)


#### 処理の流れ
|カメラ|360度画像|光源マスク|結果|
|---|---|---|---|
|![image](https://github.com/user-attachments/assets/18f011ca-5914-447e-83a2-cda49ebdcc4e)|![image](https://github.com/user-attachments/assets/7b93d271-94ac-419d-baac-a7c5d903ceae)|![スクリーンショット 2025-02-11 220551](https://github.com/user-attachments/assets/69e28ed3-e252-4e20-b0f2-33aa880ad82b)|![スクリーンショット 2025-02-11 223140](https://github.com/user-attachments/assets/cc258f9f-cd30-4a14-850f-0a21472e105f)


　　上360度カメラの画像から、ピクセルの明るさで光源を判断し光源の方向を推定、Unity Directional Lightに適用

###  アピールポイント
![image](https://github.com/user-attachments/assets/2da7d9eb-4c8c-4804-b4ce-96f55c92fd87)
![image](https://github.com/user-attachments/assets/dc598b24-31cf-405d-9de9-284b61e851e1)
![image](https://github.com/user-attachments/assets/9db9d77c-41b7-4f79-b81a-1654000ad938)
![image](https://github.com/user-attachments/assets/1c634b00-5cda-437e-b8ec-f039bc5a1bba)
![image](https://github.com/user-attachments/assets/564180af-4e83-488a-a716-9c58b3efcce1)


## 3D再構築

深度推定AIモデル

Midas
Rene Ranftl, Katrin Lasinger, David Hafner, Konrad ´
Schindler, and Vladlen Koltun. Towards robust monocular
depth estimation: Mixing datasets for zero-shot cross-dataset
transfer. IEEE Transactions on Pattern Analysis and Machine Intelligence (TPAMI), 2020

#### テストシーン
　　Assets/Debug3D/Debug3D.unity

#### 関連ソースコード

├── Assets/    

   └── /Debug3D/ 
   
     ├── DepthMeshIndirect.cs : GPUInstancingで深度画像から3Dモデルを再構築
     
     ├── DepthMeshIndirect.compute : GPUInstancing
     
     ├── RunAI.cs : 深度推定AIモデルで画像の深度を推定する
     
     ├── Tex2Cube.cs : 深度推定の後処理結果をDepthMeshIndirectで実行する
     
     └── /Postprocess/ 
     
        └─── Postprocess.cs　: 深度推定画像の後処理
        

##### 実行結果
　　![image](https://github.com/user-attachments/assets/629de104-6941-4175-8427-d54bcfb954fd)

#### 処理の流れ
|カメラ|360度画像|フィルタ済み深度推定|結果|
|---|---|---|---|
|![image](https://github.com/user-attachments/assets/6a799a6c-339e-4bc4-a462-c61c24263eff)|![image](https://github.com/user-attachments/assets/7b93d271-94ac-419d-baac-a7c5d903ceae)|![image](https://github.com/user-attachments/assets/54389e90-a957-4b8c-8b94-a97dec9cf1a8)|![image](https://github.com/user-attachments/assets/39685b15-62c1-4f3e-ad00-2d2162cd2533)

　　下360度カメラの画像から、深度を推定、一定距離以内の各ピクセルをキューブ化し、３Dシーンを再構築

###  アピールポイント
![image](https://github.com/user-attachments/assets/61cf4500-42ad-40c7-9721-a018e1c33e40)
![image](https://github.com/user-attachments/assets/e4581f11-6c30-450c-a8d0-8f2ee3ce1995)



### 今後の課題
![image](https://github.com/user-attachments/assets/90f31bb5-1dc6-4002-ab88-6f42b67c829e)
![image](https://github.com/user-attachments/assets/bf6ad0cd-a759-4247-a244-46c4630dcb3e)







