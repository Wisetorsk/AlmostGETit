class Supershape {
    constructor(
        steps=10000,
        n1 = (Math.random() * 20) + 5,
        n2 = (Math.random() * 20) + 5,
        n3 = (Math.random() * 20) + 10,
        m1 = (Math.random() * 20) + 20,
        m2 = (Math.random() * 20) + 20,
        a = (Math.random() * 10) ,
        b = (Math.random() * 10) ,
        factor = 3) {
        this.range = [...Array(steps).keys()].map(i => i*2*Math.PI*factor / (steps - 1));
        this.parameters = {
            drawSteps: steps,
            n1: n1,
            n2: n2,
            n3: n3,
            m1: m1,
            m2: m2,
            a: a,
            b: b,
            factorPI: factor
        };
        this.points = {
            x: [],
            y: []
        };
    }

    map(offsetX, offsetY, scale) {
        for (let i of this.range) {
            const r = this.calculate(i);
            this.points.x.push((r * Math.cos(i)) * scale + offsetX);
            this.points.y.push((r * Math.sin(i)) * scale + offsetY);
        }
    }

    showParams() {
        console.table(this.parameters);
    }

    newShape(offsetX = 0, offsetY = 0, scale = 1, canvas = false) {
        if (canvas) {
            canvas.wipe();
        }
        this.points = {
            x: [],
            y: []
        }
        this.parameters = {
            steps:10000,
            n1: (Math.random() * 20) + 5,
            n2: (Math.random() * 20) + 5,
            n3: (Math.random() * 20) + 10,
            m1: (Math.random() * 20) + 20,
            m2: (Math.random() * 20) + 20,
            a: (Math.random() * 10),
            b: (Math.random() * 10),
            factor: (Math.random() * 5) + 3
        }
        this.map(offsetX, offsetY, scale);
    }

    calculate(theta) {
        //const part1 = Math.abs((Math.cos((this.parameters.m1 * theta) / 4)) / 4) ^ this.parameters.n2;
        //const part2 = Math.abs((Math.sin((this.parameters.m2 * theta) / 4)) / 4) ^ this.parameters.n3;
        //const r = (part1 + part2) ^ (-1 / this.parameters.n1);

        let part1 = (1 / this.parameters.a) * Math.cos(theta * this.parameters.m1 / 4);
        part1 = Math.abs(part1);
        part1 = Math.pow(part1, this.parameters.n2);

        let part2 = (1 / this.parameters.b) * Math.sin(theta * this.parameters.m2 / 4);
        part2 = Math.abs(part2);
        part2 = Math.pow(part2, this.parameters.n3);

        let part3 = Math.pow(part1 + part2, -1 / this.parameters.n1);

        const r = 1 / part3;
        return r;
        //{
        //x: r * Math.cos(theta),
        //y: r * Math.sin(theta)
        //};
    }
}

class Painter {
    constructor(canvasId) {
        this.canvas = document.getElementById(canvasId);
        this.ctx = this.canvas.getContext("2d");
        this.width = this.canvas.width;
        this.height = this.canvas.height;
        this.color = "#FFFFFF";
    }

    setColor(color = false) {
        if (color) {
            this.ctx.strokeStyle = color;
        } else {
            this.ctx.strokeStyle = this.color;
        }
    }

    line(from, to) {
        if (typeof (from) != "object" || typeof (to) != "object") {
            throw "From / To, needs to be in object form with {x: 'X-coordinate', y: 'Y-coordiante'}"
        }
        if (!from.x || !from.y || !to.x || !to.y) throw "Both objects must contain x and y values with x and y keys. {x: 'X-coordinate', y: 'Y-coordiante'}"
        this.ctx.moveTo(from.x, from.y);
        this.ctx.lineTo(to.x, to.y);
    }

    drawArc(from, to, rotation = false) {
        this.ctx.beginPath();
        let radius = Math.abs(((to - from) / 2));
        let center = (from < to) ? (from + radius) : (from - radius);
        this.ctx.arc(center, 300, radius, 0, Math.PI, rotation);
        this.ctx.stroke();
    }

    drawShape(xy) {
        console.log('draw');
        //console.log(xy);
        this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
        this.ctx.beginPath();
        for (let index = 0; index < xy.x.length; index++) {
            const x = xy.x[index];
            const y = xy.y[index];
            this.ctx.lineTo(x, y);
        }
        this.ctx.stroke();
    }

    wipe() {
        this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
        this.ctx.beginPath();
    }

    pixelMap(dataset) {
        const imgData = new Uint8ClampedArray(this.width * this.height * 4);
        if (dataset.length === imgData.lenght) { // RGBA
            for (let i = 0; i < imgData.length; i += 4) {
                imgData[i + 0] = dataset[i + 0]; // R
                imgData[i + 1] = dataset[i + 1]; // G 
                imgData[i + 2] = dataset[i + 2]; // B
                imgData[i + 3] = dataset[i + 3]; // A
                index++;
            }
        } else { // GREYSCALE
            let index = 0;
            for (let i = 0; i < imgData.length; i += 4) {
                imgData[i + 0] = dataset[index];
                imgData[i + 1] = dataset[index];
                imgData[i + 2] = dataset[index];
                imgData[i + 3] = 255;
                index++;
            }
        }
        let image = new ImageData(imgData, this.width);
        this.ctx.putImageData(image, 0, 0);
    }
}