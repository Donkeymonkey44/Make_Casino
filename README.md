Casino Program
========================
![image](https://user-images.githubusercontent.com/107422790/222946146-c8d7cfc2-61e0-4467-85cb-e4c5c1305556.png)\
제작자 : 한정호\
제작기간 : 2주 (2023.02.20 ~ 2023.03.05)
-------------------------

# 목차
* [게임방법](#게임방법)
* [게임종류](#게임종류)
    * [블랙잭](#블랙잭)
    * [파이브포커](#파이브포커)
    * [룰렛](#룰렛)
* [기술스택](#기술스택)

# 게임방법
- 이름을 입력한 뒤 해당하는 파일이 있으면(이전 플레이 기록이 있으면) 불러옵니다.
- 없으면 새로 생성한 뒤 10000원을 지급합니다.
- 입구에서 게임을 선택하여 게임을 진행합니다.
- 게임을 끝낼때마다 다시 할지 선택할 수 있으며, 카지노를 나올 수 있습니다.
- 소지금이 0이 되면 강제종료됩니다.

# 게임종류
## 블랙잭
A, 2 ~ 10, J, Q, K 의 카드로 딜러와 대결을 해서 카드의 합이 21에 더 가까운 쪽이 승리하는 게임입니다.\
J, Q, K 는 10으로 간주하며, A는 1 또는 11 로 원하는 수로 정할 수 있습니다.\
플레이어는 처음에 두 장의 카드를 받고 그 이후로 원하는 만큼 카드를 받을 수 있습니다.\
딜러는 카드의 합이 16이 넘지 않으면 무조건 카드를 더 받고 21이 넘으면 패배합니다.\
플레이어는 21이 넘으면 무조건 패배합니다. 딜러가 21이 넘어도 무승부가 아닌 패배로 간주합니다.\
배당은 2배로 고정이며 패배하면 잃습니다. 예외로 처음 받은 두 카드로 21을 만들었을 시 2.5배의 배당을 갖습니다.\
딜러와 플레이어의 수의 합이 같을 경우 무승부로 베팅금을 돌려받습니다.\

![image](https://user-images.githubusercontent.com/107422790/222947801-837c7260-bb03-4119-b74a-460fed311f76.png)


## 파이브포커
♠, ♣, ◈, ♥ 4종류 모양의 카드가 7 ~ 10, J, Q, K, A 총 32장의 카드로 플레이 합니다.\
5장의 카드로 만드는 족보에 따른 배당률을 갖습니다.\
\
배당률은 다음과 같습니다.
* 탑     0 배
* 원페어     0.5 배
* 투페어     1.0 배
* 트리플     1.5 배
* 스트레이트     2.5 배
* 플러시     4.0 배
* 풀 하우스     5.0 배
* 포카드     7.5 배
* 스트레이트 플러시     10.0 배
* 로얄 스트레이트 플러시     15.0 배\

![image](https://user-images.githubusercontent.com/107422790/222947832-4912b02f-63e2-4254-a354-0644a2aeaa89.png)


## 룰렛
1 부터 100 까지 중 랜덤한 숫자가 정해집니다.\
숫자를 맞추는 방식에 따라 배당이 달라집니다.\
방식은 홀짝, 1/4, 10의 자리수 맞추기, 숫자 맞추기 가 있습니다.\
배당은 순서대로 1.5배, 2.5배, 5배, 10배 입니다.\

![image](https://user-images.githubusercontent.com/107422790/222947863-21129e4b-4b50-4cf8-8e72-48915d26bd24.png)


# 기술스택
- Class
    - 게임의 종류에 따라 Main 문을 압축하기 위해 사용
- Console.Clear
    - 입구에서 들어올때 콘솔을 깨끗하게 하기 위해 사용
    - 새로운 게임을 시작하기에 앞서 이전 기록들을 지우기 위해 사용
- 파일 입출력
    - 이전 플레이 기록이 있다면 이어서 하기 위해 사용
    - 현재 플레이 기록을 저장하기 위해 사용
- 파일 생성
    - 이전 플레이 기록이 없다면 새로 만들기 위해 사용
- 파일 삭제
    - 소지금을 모두 잃었을 때 플레이 기록을 지우기 위해 사용
- Console.ForegroundColor
    - 게임의 설명문의 색깔을 변경하기 위해 사용
- 무한반복문 (while (true))
    - 플레이어의 선택에 따라 게임을 계속해서 진행할지 말지 결정하기 위해 사용
    - 플레이어의 선택에 실수가 있는지 확인하기 위해 사용
- if, else if 문
    - 게임 종류의 선택을 확인하기 위해 사용
    - 블랙잭
        - 게임의 승패를 확인하기 위해 사용
        - 카드의 합에 따라 A 카드의 가치(1 or 11)를 변환하기 위해 사용
    - 파이브포커
        - 족보를 확인하기 위해 사용
    - 룰렛
        - 플레이어의 당첨을 확인하기 위해 
- 배열
    - 블랙잭
        - 딜러와 플레이어가 받은 카드를 저장하기 위해 사용
    - 파이브포커
        - 플레이어가 받은 카드(문양과 숫자) 저장하기 위해 사용
    - 룰렛
        - 플레이어의 선택에 따른 배당금을 저장하기 위해 사용
- 딕셔너리
    - 블랙잭
        - string 값으로 받은 카드를 int 값으로 변환하기 위해 사용
    - 파이브포커
        - string 값으로 받은 카드를 int 값으로 변환하기 위해 사용
- Thread.Sleep
    - 블랙잭
        - 딜러의 카드 공개를 순차적으로 하기 위해 사용
    - 파이브포커
        - 플레이어가 결과를 확인할 시간을 제공하기 위해 사용
    - 룰렛
        - 룰렛이 돌아가는 연출을 사용하기 위해 사용
- Random
    - 블랙잭
        - 플레이어와 딜러에게 카드를 무작위로 제공하기 위해 사용
    - 파이브포커
        - 플레이어에게 카드를 무작위로 제공하기 위해 사용
    - 룰렛
        - 당첨 숫자를 무작위로 선택하기 위해 사용
- switch 문
    - 룰렛
        - 플레이어의 선택에 따라 당첨과 탈락의 조건을 다르게하기 위해 사용
- virtual, base
    - 룰렛
        - 동일한 게임 내에서 당첨과 탈락의 조건을 다르게하기 위해 사용
