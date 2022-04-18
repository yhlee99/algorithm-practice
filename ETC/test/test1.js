function getMaxBarrier(initialEnergy, th) {
  let answer = 0;
  let result = calculateValue(initialEnergy);

  while (result >= th) {
    console.log(result + "/" + th);
    initialEnergy = initialEnergy.map((v) => v - 1);
    result = calculateValue(initialEnergy);
    answer++;
  }

  return answer - 1;
}

function calculateValue(energy) {
  let result = energy.reduce((acc, cur, idx) => {
    if (cur > 0) {
      return (acc += cur);
    }
  }, 0);

  return result;
}
