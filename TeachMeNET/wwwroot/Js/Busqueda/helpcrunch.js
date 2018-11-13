/**
 * Created by angel on 13/03/18.
 */

(function(w,d){
    w.HelpCrunch=function(){w.HelpCrunch.q.push(arguments)};w.HelpCrunch.q=[];
    function r(){var s=document.createElement('script');s.async=1;s.type='text/javascript';s.src='https://widget.helpcrunch.com/';(d.body||d.head).appendChild(s);}
    if(w.attachEvent){w.attachEvent('onload',r)}else{w.addEventListener('load',r,false)}
})(window, document);

HelpCrunch('init', 'teachapp', {
    applicationId: 1916,
    applicationSecret: 'AZOhuX/Mt+KNlbduP01St/9QewD0m3kpyhCRbYaEgNk+RRQ93IXSRhgIS877FNcVrBatRdzToGzliJpkg7kHyg=='
});

HelpCrunch('showChatWidget');