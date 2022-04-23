function solution(participant, completion) {
  const map = new Map();

  participant.map((v) => {
    map.set(v, (map.get(v) || 0) + 1);
  });

  completion.map((v) => {
    if (map.get(v) > 1) {
      map.set(v, map.get(v) - 1);
    } else {
      map.delete(v);
    }
  });

  const answer = [...map.keys()][0];
  return answer;
}
