require('dotenv').config()


let express = require('express')
    , app = express()
    , path = require('path')
    , fs = require('fs')
    , compress = require('compression')
    , favicon = require('serve-favicon')
    , bodyParser = require('body-parser')
    , app_env = process.env.APP_ENV || 'development'
    , https = require('https');

// gzip all
app.use(compress());

// etc settings
app.use(express.static('public'));
app.set('port', process.env.APP_PORT || 3737);
app.set('views', __dirname + '/views');
app.set('view engine', 'pug');
app.use(favicon(__dirname + '/public/favicon.ico'));
app.use(bodyParser.urlencoded({
  extended: true
}));
app.use(bodyParser.json());

app.get('/', function (req, res) {
  res.sendFile('index');
});

require('./routes')(app, require('./controller'));

if (app_env == 'development') {
  app.use(function(err, req, res, next) {

    res.status(500).render('err500', {
      title: 'ouch.. 500 [dev]',
      err: err
    });
  });
}

if (app_env == 'production') {
  app.use(function(err, req, res, next) {

    res.status(500).render('err500', {
      title: 'ouch.. 500',
      err: ''
    });
  });
}

// start server here
// http
//app.listen(app.get('port'));

// https
var privateKey = fs.readFileSync('key.pem').toString();
var certificate = fs.readFileSync('cert.pem').toString();  

var options = {
  key: privateKey,
  cert: certificate
};
https.createServer(options, app).listen(app.get('port'));


console.log("-- emailsendprotect listening on port " + app.get('port') + " --");