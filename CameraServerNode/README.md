


Gonna need `sudo npm install -g nodemon`

Start with `nodemon app.js`

or better still run it like this `forever start -c nodemon app.js`

Then get git to run continuously with this `while true; do git pull; sleep 10; done`



`npm i face-api.js canvas @tensorflow/tfjs-node -save` no joy on windows or on Raspberry Pi.

Canvas seems to be the problem.

On Ubuntu `sudo apt-get install build-essential libcairo2-dev libpango1.0-dev libjpeg-dev libgif-dev librsvg2-dev`

Then `npm i face-api.js canvas @tensorflow/tfjs-node -save` and it compiles.


