# LastDream_UNITY
20.09.16 start

  1) 버튼 q는 테스트용 버튼 !
  2) 해상도 2346 x 1125 로 고정해야합니다! (스케일 임시 고정)
  
- 200921
  1) 허들충돌 버그 픽스
  2) 플레이어 y좌표 미세변경 수정 --> 발에 Boxcollider 추가
  3) 라이프 감소 시 supermode 2초간 발동 --> 무빙 속도 조절필요
  
- 200925
  1) 허들 충돌 시 무적모드 버그 픽스 --> 허들 collider 축소 ( 발밑 col이랑 충돌 안나게 줄임 )
  2) 이단점프로 변경. 두번 째 점프는 점프파워 수정해야할 듯
  
- 200927
  1) 라이프 감소시 빈하트로 표시 --> heart- 위에 heart+ 얹어놓은 상태에서 heart+ setActive(disable)
  2) 클리어씬 효과 opcaity +-

- 201009
  1) 맵 전체에 코인설치, 허들 생성기 총 일곱개
  2) 맵 확장, 스케일 변동 조심!
  3) bug)포지션 x < 0 일 때 코인 개수 올라감 대체왜??
  4) 배고파서햄버거먹음 근데 또배고프

- 201010
  1) 모든 캔버스 contant pixel 로 변경 (마무리단계에서 플랫폼 별로 scale 조정필요)
  2) topbar 길이 변경 --> position.x -17.5 에서 -23 으로 변경 --> 201024) -22.5 로 변경

- 201011
  1) supermode 충돌 논리 변경 ( 무적발동 시 [허들의 triger 발동]에서 [플레이어와 충돌하면 허들 제거]로 )
  2) 201009 3번 버그 수정 (허들이 코인에 충돌 시에도 개수 올라갔음)

- 201015
  1) 배경 건물 배치 긴-바닥 재배치 후 건물위치 수정 필요
  2) 배경이미지 축소, 하늘이미지 더 길게 --> 이제 아웃프레임 안나옴
  3) 코인 크기 축소
  4) 점프버튼 무한점프 버그 수정

- 201016
  1) 건물 재배치
  
- 201017
  1) 코인개수 재배치 시도 ( x 옆으로 상대적위치 )
  2) iPhone X 해상도 2346 x 1125 로 고정 
 
- 201018
  1) Start Scene 추가 : 시작 시 각 player 이름,코인 갯수 저장 (전역변수) !!랭크표시줄 7개로만 생성해둠(r1~r7)!!
  2) 고정 해상도에 맞게 모든 버튼, 캔버스 위치 크기 조절
  3) Text를 TextMeshPro로 바꿔봐야함 --> 그냥 Text font 20 이상이면 글씨가 사라짐 ㅜ
  4) Text 오브젝트를 포함하는 배열 생성가능??
  5) 진행바 반짝이 레이어 우선순위 

- 201019
  1) 랭킹 내림차순 (배열에서 객체로 변경)
  2) 후에 수정시 까먹지 않기 --> 
  3)  InitialGame : Player 객체들 playerlist[10]에 저장 , 시작버튼 누를 시 객체(id,0) 생성
  4)  GameDirector : 메뉴에서 그만하기로 돌아갔을 때 --> 현재 코인 갯수 객체에 저장 후 ranklist에 저장(이름은 어차피 게임 초기에 저장되니 수정필요x) 
  5)  PlayerMove : 라이프 감소로 돌아갔을 때 --> 위와 동일
  6)  스코어 순으로 정렬 후 프린트

- 201023
  1) 메인페이지(제일 첫 페이지), 스타트페이지 설정
  2) 메인에서 스타트로 넘어갈 때 SetActive로 했는데 랭킹표시 캔버스는 계속 뜰 수 밖에 없어서 메인일 때 : z축으로 500, 스타트일 때 : 1f 해놓음
  3) 폰트만 바꾸면 아주~!굳이겠어요~!

- 201024
  1) 메인페이지 배경위에 로고,별, touch 별개로 올려둠
  2) 별이랑 touch 반짝거리게 twinkle 스크립트 --> public 공동변수 많으니 수정 시 유의
  3) Clear Stage에서 그만하기 버튼 활성화 (Start Page로) --> 버튼 눌렀을 때 랭크에 들어가는게 아니라, finish line 도달하면 랭크에 추가
  
- 201026
  1) 사운드 이펙트 추가
  2) 점프, 착지, 워킹 -> 셋 다 스크립트로 구현했는데 애니메이션으로 안되나? 아무리 검색해도 안나옴! 원시적인 방법인 것 같은데 근데 어쨌든 코드로 해버림
  3) 워킹 사운드 재생할 때 Looping 체크에서 막혔는데 Update 안에서 loop를 하면 소리가 먹혀버림(아주 좋은 경험) --> isPlaying으로 체크하고 루핑재생 시키면 됨!
  4) 오늘 배운점 : 게임사운드는 음원파일 자르기가 중요하다. 타이밍이 어렵다. 사운드는 정말 어렵다!
