module.exports = function(app, obj) {
    app.get('/validate/:emails', obj.validateRecipients);
}   