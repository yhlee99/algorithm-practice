// 식량창고의 개수, 각 식량 창고에 들어간 식량의 개수를 전달해 줌
// 연속된 식량창고는 털 수 없음
// 이 때 털 수 있는 최대 식량 구하기

function solution(n, foods) {
  let table = [0, foods[0]];

  for (let i = 1; i < n; i++) {
    const max = Math.max(table[i], table[i - 1] + foods[i]);
    table.push(max);
  }

  return table.pop();
}

console.log(solution(4, [1, 3, 1, 5]));
