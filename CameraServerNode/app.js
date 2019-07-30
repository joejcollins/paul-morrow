const express = require('express')
const node_webcam = require('node-webcam');
const prom_client = require('prom-client');

const server = express()
const port = 3000

var opts = {
    //Picture related
    width: 1280,
    height: 800,
    quality: 100,
    //Delay in seconds to take shot
    delay: 0,
    //Save shots in memory
    saveShots: true,
    // [jpeg, png] support varies
    output: "jpeg",
    //Which camera to use.  Use Webcam.list() for results and false for default device
    device: false,
    // [location, buffer, base64] Webcam.CallbackReturnTypes
    callbackReturn: "location",
    //Logging
    verbose: false
};

//Creates webcam instance
const webcam = node_webcam.create( opts );

server.get('/', function (req, res) {
    webcam.capture(__dirname + '/capture', function( err, data ) {
        //res.sendFile(data);
        res.sendFile(__dirname + '/capture.jpg');
    } );
});

const collectDefaultMetrics = prom_client.collectDefaultMetrics;
const Registry = prom_client.Registry;
const register = new Registry();

server.get('/metrics', (req, res) => {
    collectDefaultMetrics({ register });
	res.set('Content-Type', register.contentType);
	res.end(register.metrics());
});



const tf = require('@tensorflow/tfjs-node')
const canvas = require('canvas')
const faceapi = require('face-api.js')


server.get('/peeps', (req, res) => {
    const imageFile = __dirname + '/capture.jpg';
    //Monkey patch
    const { Canvas, Image, ImageData } = canvas
    faceapi.env.monkeyPatch({ Canvas, Image, ImageData })
    isFace = isTherePeople(imageFile);

    //faceapi.nets.tinyFaceDetector.loadFromUri('/models')
    //const img = faceapi.bufferToImage(imgFile)
    //const detections = faceapi.detectAllFaces(img, new faceapi.TinyFaceDetectorOptions())
    res.send('I see dead people' + isFace)
});


async function isTherePeople(imageFile){
    //const image = await faceapi.bufferToImage(imageFile);
    return true;
}

server.listen(port, () => console.log(`Example app listening on port ${port}!`))
