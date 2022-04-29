function efficientJanitor(weight) {
  let count = 0;
  for (let w of weight) {
    if (w <= 1.5) {
      count++;
    }
  }

  return weight.length - Math.floor(count / 2);
}
