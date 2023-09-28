# 🛠️ WPF MVVM을 사용한 사용자 추가 제거 조회 화면 
<br>  

<div style="display: flex; justify-content: space-between;">
    <img src="https://img.shields.io/badge/C%23-1A1F71?style=for-the-badge&logo=dotnet&logoColor=white" width="200" height="80">
    <img src="https://img.shields.io/badge/C%23-007ACC?style=for-the-badge&logo=visualstudio&logoColor=white" width="200" height="80">
    <img src="https://img.shields.io/badge/xaml-FF4B4B?style=for-the-badge&logo=xaml&logoColor=white" width="200" height="80">
</div>
<br>

### 코드 설명
#### 사용자를 추가 삭제 필터링하는 WPF 어플리케이션

 <img src=https://github.com/psk0812/clientinfo/assets/130532081/d7a1a854-bffe-4edc-b15c-554286a43eee)>



## 조건
- 초기 멤버 10명은 삭제가 안된다. 그 이후에는 삭제가능
- 처리시에 1초 이상의 시간을 둔다.
- MVVM사용
- 바인딩 사용
 
## 🗂️ 전체 Repository 구조
### Command파일
- RelayCommand.cs

### Model파일
- data.csv
- ModelManager.cs  

### ViewModel파일
- AddClientViewModel.cs (plus.xaml와 연결)
- Viewmodel.cs (메인 뷰와 연결)

### View파일
- plus.xaml (추가시 화면-모달로 뜸)
- Window1.xaml (메인 뷰화면)
  
  




