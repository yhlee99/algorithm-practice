function solution(arrA, arrB) {
  let a = arrA;

  for (let i = 0; i < arrB.length; i++) {
    arrB.unshift(arrB.pop());

    if (arrA.toString() == arrB) {
      return true;
    }
  }

  return false;
}
