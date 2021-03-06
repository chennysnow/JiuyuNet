//校验字符串是否为整型
function isInt(str){if(str == "")return true;if(/^(\\-?)(\\d+)$/.test(str))return true;else return false;}
//校验整型是否为正数
function isNotNegativeInteger(str){if(str == "")return true;if(checkIsInteger(str)==true){if(parseInt(str,10) < 0) return false;else return true;}else return false;}
//校验字符串是否为浮点型
function isDouble(str){if(str == "")return true;if(str.indexOf(".") == -1){if(checkIsInteger(str) == true)return true;else return false;}else{if(/^(\\-?)(\\d+)(.{1})(\\d+)$/g.test(str))return true;else return false;}}
//校验浮点型是否为非负数
function isNotNegativeDouble(str){if(str == "")return true;if(checkIsDouble(str) == true){if(parseFloat(str) < 0)return false;else return true;}else return false;}
//校验字符串是否为日期型
function isDate(str){if(str == "")return true;var pattern = /^((\\d{4})|(\\d{2}))-(\\d{1,2})-(\\d{1,2})$/g;if(!pattern.test(str))return false;var arrDate = str.split("-");if(parseInt(arrDate[0],10) < 100)arrDate[0] = 2000 + parseInt(arrDate[0],10) + "";var date = new Date(arrDate[0],(parseInt(arrDate[1],10) -1)+"",arrDate[2]);if(date.getYear() == arrDate[0]&& date.getMonth() == (parseInt(arrDate[1],10) -1)+"" && date.getDate() == arrDate[2])return true;else return false;}
//校验两个日期的先后
function checkDateEarlier(strStart,strEnd){if(checkIsValidDate(strStart) == false || checkIsValidDate(strEnd) == false)return false;if (( strStart == "" ) || ( strEnd == "" ))return true;var arr1 = strStart.split("-");var arr2 = strEnd.split("-");var date1 = new Date(arr1[0],parseInt(arr1[1].replace(/^0/,""),10) - 1,arr1[2]);var date2 = new Date(arr2[0],parseInt(arr2[1].replace(/^0/,""),10) - 1,arr2[2]);if(arr1[1].length == 1)arr1[1] = "0" + arr1[1];if(arr1[2].length == 1)arr1[2] = "0" + arr1[2];if(arr2[1].length == 1)arr2[1] = "0" + arr2[1];if(arr2[2].length == 1)arr2[2]="0" + arr2[2];var d1 = arr1[0] + arr1[1] + arr1[2];var d2 = arr2[0] + arr2[1] + arr2[2];if(parseInt(d1,10) > parseInt(d2,10))return false;else return true;}
//校验字符串是否为中文
function isChinese(str){if (str == "")return true;var pattern = /^([\\u4E00-\\u9FA5]|[\\uFE30-\\uFFA0])*$/gi;if (pattern.test(str))return true;else return false;}
//得到文件的后缀名
function getFilePostfix(oFile){if(oFile == null)return null;var pattern = /(.*)\\.(.*)$/gi;if(typeof(oFile) == "object"){if(oFile.value ==null || oFile.value == "")return null;var arr = pattern.exec(oFile.value);return RegExp.$2;}else if(typeof(oFile) == "string"){var arr = pattern.exec(oFile);return RegExp.$2;}else return null;}
/********************************去除空格函数****************************************/
function LTrim(str){var i;for(i=0;i<str.length; i++){if(str.charAt(i)!=" ") break;} str=str.substring(i,str.length);return str;}
function RTrim(str){var i;for(i=str.length-1;i>=0;i--){if(str.charAt(i)!=" ") break;} str = str.substring(0,i+1);return str;}
function Trim(str){return LTrim(RTrim(str));}
/*取得用户输入的字符串的长度*/ 
function getLength(ui){var i,sum=0; for(i=0;i<ui.length;i++){if((ui.charCodeAt(i)>=0) && (ui.charCodeAt(i)<=255))sum++;else sum+=2;}return sum} 
/*判断用户输入是否为空*/ 
function isEmpty(ui){return (Trim(ui)==null||Trim(ui)=="");} 
/*是否为数字、字母或下划线*/ 
function isName(ui){var valid=/^[a-zA-Z_\x7f-\xff][a-zA-Z0-9_\x7f-\xff]*/;return (valid.test(ui));}  
/*判断是否为身份证号码*/ 
function isId(ui){var valid=/(^\d{16}$)|(^\d{18}$)/;return (isEmpty(ui)||valid.test(ui));} 
/*判断是否为邮政编码*/ 
function isPostcode(ui){var valid=/^\d{6}$/;return (isEmpty(ui)||valid.test(ui));} 
/*判断是否为固定电话*/ 
function isChinaTel(ui){var valid=/[0-9]{3,4}-[0-9]{7,8}$/;return (isEmpty(ui)||valid.test(ui));}  
/*判断是否为移动电话*/ 
function isChinaMob(ui){var valid=/^(?:13|15|18)[0-9]{9}$/;return (isEmpty(ui)||valid.test(ui));}  
/*判断是否为电话，只能为固定电话或移动电话*/ 
function isTel(ui){var valid=/([0-9]{3,4}-[0-9]{7,8}$)|(^(?:13\d|15[89])-?\d{5}(\d{3}|\*{3})$)/; return (isEmpty(ui)||valid.test(ui));} 
/*判断是否为邮件*/ 
function isMail(ui){if(isEmpty(ui)){return true;}var notValid=/(@.*@)|(\.\.)|(@\.)|(\.@)|(^\.)|(^\-)|(\-\.)|(\.\-)/; var valid=/^.+\@[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}$/; return (!notValid.test(ui)&&valid.test(ui));}  
/*用户输入字符串长度是否在两值之间*/ 
function isLenBetween(ui,minl,maxl){var len=ui.length;return (len>=minl&&len<=maxl);}	  
/*判断输入的是否为数字*/
function isNumber(ui){var valid=/^[0-9]+.?[0-9]*$/;return (isEmpty(ui)||valid.test(ui));}  
/*判断符是否为合法的网址*/
function isUrl(ui){var valid=/^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&amp;_~`@[\]\':+!]*([^&lt;&gt;\"\"])*$/;return (isEmpty(ui)||valid.test(ui));}