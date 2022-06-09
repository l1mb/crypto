export const НодДвухЧисел = (num1, num2) => {
    let a = Math.abs(num1);
    let b = Math.abs(num2);
    while (a && b && a !== b) {
       if(a > b){
          [a, b] = [a - b, b];
       }else{
          [a, b] = [a, b - a];
       };
    };
    return a || b;
 };

 export const НодБольшеЧемДвухЧисел  = (input:number[]) => {
        var len, a, b;
          len = input.length;
          if ( !len ) {
              return null;
          }
          a = input[ 0 ];
          for ( var i = 1; i < len; i++ ) {
              b = input[ i ];
              a = НодДвухЧисел( a, b );
          }
          return a;      
 }

 export const ПростыеЧисла = (n: number)=> {
     const primeArr:number[] = [1]
    nextPrime:
    for (let i = 2; i <= n; i++) { // Для всех i...
    
      for (let j = 2; j < i; j++) { // проверить, делится ли число..
        if (i % j == 0) continue nextPrime; // не подходит, берём следующее
      }
      primeArr.push(i);

    }
    return primeArr;
 }