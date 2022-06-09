import { НодДвухЧисел, НодБольшеЧемДвухЧисел, ПростыеЧисла } from "./nod";
console.clear();

const num1= 431, num2=471;
const arr: number[] = [6, num1, num2];
console.log(`Нод ${num1} и ${num2} = ` + НодДвухЧисел(num1, num2));
console.log(`Нод чисел ${arr}=` + НодБольшеЧемДвухЧисел(arr))
console.log(`Массив простых чисел: ` + ПростыеЧисла(99))