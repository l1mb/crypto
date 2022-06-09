export const lowerCaseAlp = ['а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'і',
                   'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
                   'у', 'ў', 'ф', 'х', 'ц', 'ч', 'ш', 'ь', 'ы', 'э',
                   'ю', 'я'];

export const upperCaseAlp = lowerCaseAlp.map(el=>el = el.toUpperCase());

const rot = 21;

export const ceaserCiphher = (text, rot) => {
    text = text.toLowerCase().split('').map(item => item==='ё'?'e':item).join('')
    //skaradumau
        //const key = 'skardumbcefghijlnopqtvwxyz'+'skardumbcefghijlnopqtvwxyz'.toUpperCase()
        const key = 'абвгдежзийклмнопрстуфхцчшщъыьэюя'
        let result = ""
        for (const textElement of text) {
            const temp = textElement.codePointAt(0)+21;
            console.log('temp ',temp);
            result+= String.fromCodePoint(temp>'я'.codePointAt(0)? ('a'.codePointAt(0)+temp-'я'.codePointAt(0)):temp)
            //console.log(temp)
            //result +=  key[temp - 'а'.codePointAt(0)] || temp;
        }
        return result
}


export const дешифрЦезаря = (text, rot) => {
    const decode2 = (text) => {
        text = text.toLowerCase().split('').map(item => item==='ё'?'e':item).join('')
        //skaradumau
        //const key = 'skardumbcefghijlnopqtvwxyz'+'skardumbcefghijlnopqtvwxyz'.toUpperCase()
        const key = 'скордумвабгежзийлнптфхцчшщъыьэюя'//+'скордумвабгеёжзийлнптфхцчшщъыьэюя'.toUpperCase()
        const dekey = 'абвгдежзийклмнопрстуфхцчшщъыьэюя'//+'абвгдеёжзийклмнопрстуфхцчшщъыьэюя'.toUpperCase()
    
        let result = ""
        for (const textElement of text) {
                result += dekey[key.indexOf(textElement)] || textElement;//dekey[key.indexOf(textElement.codePointAt(0) - 'а'.codePointAt(0))] || textElement;
        }
        return result
    }
    
}

export const enc = (char) => {
    const letter = char.charCodeAt(0);
    
    return lowerCaseAlp[(letter + 21 >1103 ? 1072+ (letter+21-1072): letter) % lowerCaseAlp.length]
}

// как мы находим модуль отрицательного числа?

export const decr = (char) => {
    const letter = char.charCodeAt(0);

    return lowerCaseAlp[(letter-21 < 1072? 1103 - (letter - 21 + 1103): letter) % lowerCaseAlp.length]
}
