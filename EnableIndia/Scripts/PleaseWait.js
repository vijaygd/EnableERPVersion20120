Sys.Application.add_init(function() {
  // Allows the div.blockMsg style in CSS to
  //  override BlockUI's defaults.
  $.blockUI.defaults.css = {};

  // Add the BlockUI call as an onclick handler
  //  of the Save button.
  $addHandler($get('btnGet'), 'click', function () {
      $('#formStatusFullPage').block({ message: null });
  });
  
  // Get a reference to the PageRequestManager.
  var prm = Sys.WebForms.PageRequestManager.getInstance();

  // Unblock the form when a partial postback ends.
  prm.add_endRequest(function() {
      $('#formStatusFullPage').unblock();
  });
});

// Bonus! Progress indicator preloading.
var preload = document.createElement('img');
preload.src = '../image/pleasewait.gif';
delete preload;