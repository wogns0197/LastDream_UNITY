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
  2) topbar 길이 변경 --> position.x -17.5 에서 -23 으로 변경 

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
  
