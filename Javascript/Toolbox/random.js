class Random {

    static randint(first, last=false) {
        if(!last) {
            return Math.floor(Math.random()*first);
        } else {
            return first + Math.floor(Math.random()*((last-first)+1));
        }
    }

    static randRange(numbers) {
        return [...Array(numbers).keys()].map(i => Math.random())
    }

    static randIntRage(numbers, first, last=false) {
        return [...Array(numbers).keys()].map(i => Random.randint(first, last))
    }
}

class Range {

    static range(length) {
        return [...Array(length).keys()]
    }
}