function solution(priorities, location) {
  const stack = [];
  let currentIndex = 0; // Queue 처리를 위해 Index 추가
  let order = 1;

  // Stack에 [index, value] 형태로 추가
  for (let i = 0; i < priorities.length; i++) {
    stack.push([i, priorities[i]]);
  }

  // 맨 앞 index, value 빼냄
  for (let [index, value] of stack) {
    currentIndex++;
    let isMax = true;

    for (let i = currentIndex; i < stack.length; i++) {
      if (value < stack[i][1]) {
        // 더 큰 값이 있을 경우 맨 뒤로 보냄
        stack.push([index, value]);
        isMax = false;

        break;
      }
    }

    // 가장 큰 값이였을 경우 location과 비교
    if (isMax) {
      if (index === location) {
        return order;
      }

      order++;
    }
  }
}
