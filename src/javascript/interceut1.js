wa_account="interceut1"; wa_location=1;
wa_pageName=location.pathname;  // you can customize the page name here
document.cookie='__support_check=1';wa_hp='http';
wa_rf=document.referrer;wa_sr=window.location.search;
wa_tz=new Date();if(location.href.substr(0,6).toLowerCase()=='https:')
wa_hp='https';wa_data='&an='+escape(navigator.appName)+ 
'&sr='+escape(wa_sr)+'&ck='+document.cookie.length+
'&rf='+escape(wa_rf)+'&sl='+escape(navigator.systemLanguage)+
'&av='+escape(navigator.appVersion)+'&l='+escape(navigator.language)+
'&pf='+escape(navigator.platform)+'&pg='+escape(wa_pageName);
wa_data=wa_data+'&cd='+
screen.colorDepth+'&rs='+escape(screen.width+ ' x '+screen.height)+
'&tz='+wa_tz.getTimezoneOffset()+'&je='+ navigator.javaEnabled();
wa_img=new Image();wa_img.src=wa_hp+'://loc1.hitsprocessor.com/statistics.asp'+
'?v=1&s='+wa_location+'&acct='+wa_account+wa_data+'&tks='+wa_tz.getTime();
document.getElementById('wa_u').src=wa_hp+'://loc1.hitsprocessor.com/track.js';
