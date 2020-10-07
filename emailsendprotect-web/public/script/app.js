var mailboxItem;
var dialog;

Office.initialize = function (reason) {
  mailboxItem = Office.context.mailbox.item;
};

// Invoke by Contoso Subject and CC Checker add-in before send is allowed.
// <param name="event">MessageSend event is automatically passed by BlockOnSend code to the function specified in the manifest.</param>
function validateRecipients(event) {
  var toList = [];
  mailboxItem.to.getAsync({ asyncContext: event }, function (asyncResult) {
    if (asyncResult.status === Office.AsyncResultStatus.Succeeded) {
      toList = asyncResult.value;
      openDialogAsIframe();
    }
  });
}

function dialogCallback(asyncResult) {
  if (asyncResult.status == "failed") {
    // In addition to general system errors, there are 3 specific errors for
    // displayDialogAsync that you can handle individually.
    switch (asyncResult.error.code) {
      case 12004:
        console.log("Domain is not trusted");
        break;
      case 12005:
        console.log("HTTPS is required");
        break;
      case 12007:
        console.log("A dialog is already opened.");
        break;
      default:
        console.log(asyncResult.error.message);
        break;
    }
  } else {
    dialog = asyncResult.value;
    /*Messages are sent by developers programatically from the dialog using office.context.ui.messageParent(...)*/
    dialog.addEventHandler(
      Office.EventType.DialogMessageReceived,
      messageHandler
    );

    /*Events are sent by the platform in response to user actions or errors. For example, the dialog is closed via the 'x' button*/
    dialog.addEventHandler(Office.EventType.DialogEventReceived, eventHandler);
  }
}

function messageHandler(arg) {
  dialog.close();
  console.log(arg.message);
}

function eventHandler(arg) {
  // In addition to general system errors, there are 2 specific errors
  // and one event that you can handle individually.
  switch (arg.error) {
    case 12002:
      console.log("Cannot load URL, no such page or bad URL syntax.");
      break;
    case 12003:
      console.log("HTTPS is required.");
      break;
    case 12006:
      // The dialog was closed, typically because the user the pressed X button.
      console.log("Dialog closed by user");
      break;
    default:
      console.log("Undefined error in dialog window");
      break;
  }
}

function openDialog(participants) {
  var emails = JSON.stringify(encodeURIComponent(participants));
  var url = window.location.origin + "/validate/" + emails;

  Office.context.ui.displayDialogAsync(
    url,
    { height: 50, width: 50 },
    dialogCallback
  );
}

function openDialogAsIframe(participants) {
  var emails = JSON.stringify(encodeURIComponent(participants));
  var url = window.location.origin + "/validate/" + emails;

  //IMPORTANT: IFrame mode only works in Online (Web) clients. Desktop clients (Windows, IOS, Mac) always display as a pop-up inside of Office apps.
  Office.context.ui.displayDialogAsync(
    url,
    { height: 50, width: 50, displayInIframe: true },
    dialogCallback
  );
}
