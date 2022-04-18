function solution(participant, completion) {
  let testObject = new Object();

  completion.forEach((value) => {
    testObject[value] = -1;
  });

  let result = participant.filter(
    (value) => !Object.keys(testObject).includes(value)
  );

  return result[0];
}

// 출력 예
// participant	completion	return
// ["leo", "kiki", "eden"]	["eden", "kiki"]	"leo"
// ["marina", "josipa", "nikola", "vinko", "filipa"]	["josipa", "filipa", "marina", "nikola"]	"vinko"
// ["mislav", "stanko", "mislav", "ana"]	["stanko", "ana", "mislav"]	"mislav"
