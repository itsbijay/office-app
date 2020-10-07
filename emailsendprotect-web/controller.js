exports.validateRecipients = function (req, res, next) {
    var emails = JSON.parse(decodeURIComponent(req.params.emails));
    res.render('validate', {
        participants: emails
    });
}