var collapseAll = false;
$(document).ready(function () {
    $.ajax({
        url: "http://localhost:25869/api/AccountsHead/GetOnlyRoot",  // Replace with your API endpoint
        type: "GET",
        contentType: "json",
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        success: function (data) {
            // Assuming 'data' is an array of objects like [{id: 1, name: 'Option 1'}, {id: 2, name: 'Option 2'}, ...]
            var dropdown = $("#RootId");
            dropdown.empty();  // Clear any existing options

            // Add a default option
            dropdown.append('<option value="">Select an option</option>');
            console.log("dd", data.$values);
            // Loop through the data and append options to the dropdown
            $.each(data.$values, function (key, entry) {
                dropdown.append($('<option></option>').attr('value', entry.id).text(entry.headName));
            });
        },
        error: function (error) {
            console.log("Error fetching dropdown options:", error);
        }
    });

    $.ajax({
        url: "http://localhost:25869/api/AccountsHeadType",  // Replace with your API endpoint
        type: "GET",
        contentType: "application/json",
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        success: function (data) {
            // Assuming 'data' is an array of objects like [{id: 1, name: 'Option 1'}, {id: 2, name: 'Option 2'}, ...]
            var dropdown = $("#AccountsHeadTypeId");
            dropdown.empty();  // Clear any existing options

            // Add a default option
            dropdown.append('<option value="">Select an option</option>');
            console.log("dd", data.$values);
            // Loop through the data and append options to the dropdown
            $.each(data.$values, function (key, entry) {
                dropdown.append($('<option></option>').attr('value', entry.id).text(entry.name));
            });
        },
        error: function (error) {
            console.log("Error fetching dropdown options:", error);
        }
    });
  
    loadHistoryTable();
    //$("#IsMale").attr('checked', true);

});
$(document.body).on("click", "#btnClear", function () {
    refressForm();
});

$(document.body).on("click", "#btnSubmit", function () {
    var vm = {};
    var id = $("#Id").val();
    vm.HeadName = $("#HeadName").val();
    vm.RootLeaf = $("#RootLeaf").val();
    var selectedText = $("#AccountsHeadTypeId option:selected").text();
    var firstCharacter = selectedText.charAt(0);  // 'S', 'C', 'C' for the options above

    vm.HeadType = firstCharacter;
    vm.OpeningBal = $("#OpeningBal").val() == '' ? '0' : $("#OpeningBal").val();
    vm.RootId = $("#RootId").val() == '' ? null : $("#RootId").val();
    vm.RootName = $("#RootName").val();
    vm.Code = $("#Code").val();
    vm.AccountsHeadTypeId = $("#AccountsHeadTypeId").val();

    console.log("vm data", vm);
    if (id == "" || id == 0 || id == null) {
        $.ajax({
            url: "http://localhost:25869/api/AccountsHead",
            data: JSON.stringify(vm), // Convert the data to JSON format
            type: "POST",
            contentType: "application/json",
            "headers": {
                "Authorization": "Bearer " + localStorage.getItem("token")
            },
            success: function (e) {
                console.log("confirm", e);
                if (e > 0 || e.id>0) {
                    toastr.success("Save Success.", "Success!!!");
                    refressForm();
                    loadHistoryTable();
                } else {
                    toastr.warning("Save Fail.", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    } else {
        vm.Id = id;
        console.log("vm data", JSON.stringify(vm));
        $.ajax({
            url: "http://localhost:25869/api/AccountsHead?id=" + id,
            data: JSON.stringify(vm),
            type: "PUT",
            contentType: "application/json",
            "headers": {
                "Authorization": "Bearer " + localStorage.getItem("token")
            },
            success: function (e) {
                if (e > 0 || e.id > 0) {
                    toastr.success("Update Success", "Success!!!");
                    refressForm();
                    loadHistoryTable();
                } else {
                    toastr.warning("Update Fail.", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }

});


function refressForm() {
    $("#Id").val('');
   
    $("#HeadName").val('');
   $("#RootLeaf").val('');
   $("#HeadType").val('');
   $("#OpeningDate").val('');
   $("#OpeningBal").val('');
   $("#RootId").val('');
   $("#RootName").val('');
   $("#Code").val('');
   $("#AccountsHeadTypeId").val('');

    vm.AccountsHeadTypeName = $("#AccountsHeadTypeName").val('');
}

function loadHistoryTable() {

    $.ajax({
        url: "http://localhost:25869/api/AccountsHead/GetFirstLevelParentHead",  // Replace with your API endpoint
        type: "GET",
        contentType: "application/json",
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        success: function (data) {
            var treeDiv = $("#tree");
            var treeHtml = buildTreeHtml(data.$values, collapseAll);  // Generate the tree HTML
            treeDiv.html(treeHtml);  // Insert the tree HTML into the div

            // Add click event to load children dynamically when a parent is clicked
            $("#tree").on("click", "li > span", function () {
                var spanElement = $(this);
                var parentId = spanElement.attr('data-id');  // Get the data-id attribute of the parent node

                // Check if children have already been loaded
                if (!spanElement.siblings('ul').length) {
                    // Make an API call to load children dynamically for the clicked parent
                    $.ajax({
                        url: "http://localhost:25869/api/AccountsHead/GetAccountHeadByRootId/" + parentId,  // API to fetch child nodes
                        type: "GET",
                        contentType: "application/json",
                        "headers": {
                            "Authorization": "Bearer " + localStorage.getItem("token")
                        },
                        success: function (childData) {
                            // Build and append the child nodes
                            var childHtml = buildTreeHtml(childData.$values, collapseAll);
                            spanElement.after(childHtml);  // Insert the child HTML after the parent span
                            spanElement.toggleClass("collapsed");  // Toggle the collapsed state
                            spanElement.siblings('ul').toggle();  // Show the children
                        },
                        error: function (error) {
                            console.log("Error fetching child nodes:", error);
                        }
                    });
                } else {
                    // If children are already loaded, just toggle their visibility
                    spanElement.siblings('ul').toggle();
                    spanElement.toggleClass("collapsed");
                }
            });
            $("#tree").on("click", ".edit-btn", function () {
                var nodeId = $(this).attr('data-id');  // Get the node's ID
                editNode(nodeId);  // Call the function to edit the node
            });
        },
        error: function (error) {
            console.log("Error fetching tree data:", error);
        }
    });

    // Function to generate tree HTML (only parent nodes initially)
    function buildTreeHtml(nodes, collapse) {
        if (!nodes || nodes.length === 0) return '';  // Base case

        var html = '<ul>';
        $.each(nodes, function (index, node) {
           
            if (node.rootLeaf == 'R') {
                html += '<li>';
                html += '<span class="node-label collapsed" data-id="' + node.id + '">' + node.code + '-' + node.headName + '</span>';
                html += '<i class="fas fa-edit edit-btn" data-id="' + node.id + '" style="cursor: pointer; color: #007bff; margin-left: 10px;"></i>';
            }// Clickable parent node, with data-id for the API call
            else {
                html += '<li>' + node.code + '-' + node.headName;
                html += ' <i class="fas fa-edit edit-btn" data-id="' + node.id + '" style="cursor: pointer; color: #007bff; margin-left: 10px;"></i>';
            }
            // Child nodes are not rendered initially
            html += '</li>';
        });
        html += '</ul>';

        return html;
    }
    function editNode(nodeId) {
        $.ajax({
            url: "http://localhost:25869/api/AccountsHead/" + nodeId,  // API to get node details
            type: "GET",
            contentType: "application/json",
            "headers": {
                "Authorization": "Bearer " + localStorage.getItem("token")
            },
            success: function (data) {
                console.log("select data",data)
                // Populate the form with the data
                $("#Id").val(data.id);

                $("#HeadName").val(data.headName);
                $("#RootLeaf").val(data.rootLeaf);
                $("#HeadType").val(data.headType);
                $("#OpeningDate").val(data.openingDate);
                $("#OpeningBal").val(data.openingBal);
                $("#RootId").val(data.rootId);
                $("#RootName").val(data.rootName);
                $("#Code").val(data.code);
                $("#AccountsHeadTypeId").val(data.accountsHeadTypeId);
                // Populate other input fields as needed
            },
            error: function (error) {
                console.log("Error fetching node details:", error);
            }
        });
    }

    // Button to toggle all nodes (collapse/expand all)
    $("#toggleAll").click(function () {
        var ulElements = $("#tree ul");
        if (collapseAll) {
            ulElements.hide();  // Collapse all
        } else {
            ulElements.show();  // Expand all
        }
        collapseAll = !collapseAll;  // Toggle state
    });
}
