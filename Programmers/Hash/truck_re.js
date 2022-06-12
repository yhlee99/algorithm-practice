function solution(bridge_length, weight, truck_weights) {
  let bridgeQueue = []; // [weight, time]
  let time = 1;

  bridgeQueue.push([truck_weights[0], 0]);
  let truckSum = truck_weights[0];
  let truckIndex = 1;

  // 남아있는 트럭 없을 때 까지 반복
  while (truckIndex < truck_weights.length || bridgeQueue.length > 0) {
    // 1초 지남
    time++;
    for (let i = 0; i < bridgeQueue.length; i++) {
      bridgeQueue[i][1]++;
    }

    // 맨 앞 트럭 빠져나갈 수 있으면 뺴기
    if (bridgeQueue[0][1] >= bridge_length) {
      truckSum -= bridgeQueue[0][0];
      bridgeQueue.shift();
    }

    // 다리에 트럭 올라갈 수 있으면 올리기
    if (truck_weights[truckIndex] + truckSum <= weight) {
      bridgeQueue.push([truck_weights[truckIndex], 0]);
      truckSum += truck_weights[truckIndex];
      truckIndex++;
    }
  }

  return time;
}
