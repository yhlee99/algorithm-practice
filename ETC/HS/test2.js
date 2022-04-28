function solution(movie) {
  const map = new Map();

  movie.forEach((element) => {
    if (map.has(element)) {
      map.set(element, map.get(element) + 1);
    } else {
      map.set(element, 0);
    }
  });

  const mapSort = [...map].sort((a, b) => {
    if (a[1] === b[1]) {
      if (a[0] < b[0]) {
        return -1;
      }
      if (a[0] > b[0]) {
        return 1;
      }
    }
    return b[1] - a[1];
  });

  const answer = mapSort.map((v) => v[0]);
  return answer;
}
