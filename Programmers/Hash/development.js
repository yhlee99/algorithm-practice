function solution(progresses, speeds) {
  const answer = [];
  let index = 0; // Queue의 성능 Issue로 Index 방식으로 수정함

  while (index < progresses.length) {
    let needDay = calculateNeedDay(progresses[index], speeds[index]);
    index++;
    let count = 1;

    while (index < progresses.length && calculateNeedDay(progresses[index], speeds[index]) <= needDay) {
      // 배포가 가능할 경우 맨 앞에서 빼냄
      index++;
      count++;
    }

    answer.push(count);
  }

  return answer;
}

function calculateNeedDay(progress, speed) {
  return Math.ceil((100 - progress) / speed);
}
