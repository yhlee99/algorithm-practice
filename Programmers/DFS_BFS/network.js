function solution(n, computers) {
  let targetComputer = 0;
  let computerNumber = 0;
  let needVisitComputer = [];
  let visitedComputer = [];

  while (visitedComputer.length < n) {
    if (!visitedComputer.includes(targetComputer)) {
      needVisitComputer.push(computerNumber);

      while (needVisitComputer.length > 0) {
        const num = needVisitComputer.pop();
        visitedComputer.push(num);

        for (let i = 0; i < n; i++) {
          if (computers[num][i] === 1) {
            if (!visitedComputer.includes(i)) {
              needVisitComputer.push(i);
            }
          }
        }
      }

      computerNumber++;
    }

    targetComputer++;
  }

  return computerNumber;
}
