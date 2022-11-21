
//每页显示数下拉框
var lengthMenuStr = '每页显示<select class="form-control"><option value="10">10</option><option value="20">20</option><option value="30">30</option><option value="40">40</option><option value="50">50</option><option value="100">100</option><option value="500">500</option>';
//分页统计信息
var infoStr = '总共<span class="pagesStyle">(_PAGES_)</span>页 显示_START_ - _END_ 页 合计<span class="pagesStyle">_TOTAL_</span>条记录';
//Esc和Enter的onkeydown事件
document.onkeydown = function (event) {
    var e = event || window.event || arguments.callee.caller.arguments[0]; 
    if (e && e.keyCode == 27)
    {
        alert('ESC1');
    }
    if (e && e.keyCode == 13)
    {
        reloadTable();
    }
}
//获取所有CheckBox对象
function GetCheckBoxs()
{
    var table = document.getElementById("tb");
    if (table == null)
        return;
    var obj = table.getElementsByClassName("cbx");
    for (var i = 0; i < obj.length; i++) {
        if (obj[i].type == 'checkbox')
        {
            //console.log(obj[i]);
        }
    }
    return obj;
}