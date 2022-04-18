function* counter() {
  console.log("첫번째 호출");
  yield 1; // 첫번째 호출 시에 이 지점까지 실행된다.
  console.log("두번째 호출");
  yield 2; // 두번째 호출 시에 이 지점까지 실행된다.
  console.log("세번째 호출"); // 세번째 호출 시에 이 지점까지 실행된다.
  yield "test";
}

const generatorObj = counter();

console.log(generatorObj.next()); // 첫번째 호출 {value: 1, done: false}
console.log(generatorObj.next()); // 두번째 호출 {value: 2, done: false}
console.log(generatorObj.next()); // 세번째 호출 {value: undefined, done: true}
