import { text } from "./document.mjs";
import { lowerCaseAlp, upperCaseAlp, ceaserCiphher, дешифрЦезаря } from "./шифрЦезаря.mjs";
console.clear();


console.log(lowerCaseAlp);
console.log(upperCaseAlp);

console.log(lowerCaseAlp.map(el=>  el.charCodeAt(0)))
console.log(upperCaseAlp.map(el=>  el.charCodeAt(0)))


console.log(`text length: ` + text.length)


console.log(ceaserCiphher("кирилл", 21))
console.log(дешифрЦезаря("шцўцпп", 21))