import{p as j}from"./chunk-WASTHULE-L4OcE6yR.js";import{p as J}from"./wardley-RL74JXVD-T2LBEBUU-DEwddV37.js";import{g as K,s as Q,a as Y,b as tt,t as et,q as at,_ as s,l as w,c as it,H as rt,a7 as st,a8 as ot,a9 as M,aa as nt,e as lt,A as ct,ab as dt,I as pt}from"./md-DwUYoR1V.js";import"./chunk-MFRUYFWM-DmYayfL1.js";import"./index-D0V-vsek.js";import"./modules/vue-B7Wj_ih7.js";import"./modules/shiki-f2HCvbv-.js";import"./slidev/CodeBlockWrapper.vue_vue_type_script_setup_true_lang-DU49hUsR.js";import"./modules/unplugin-icons-U1181HWj.js";import"./slidev/context-6HxZYSDM.js";import"./modules/file-saver-B7oFTzqn.js";import"./slidev/two-cols-header-CAhppFJf.js";var gt=pt.pie,C={sections:new Map,showData:!1},u=C.sections,D=C.showData,ht=structuredClone(gt),ut=s(()=>structuredClone(ht),"getConfig"),ft=s(()=>{u=new Map,D=C.showData,ct()},"clear"),mt=s(({label:t,value:a})=>{if(a<0)throw new Error(`"${t}" has invalid value: ${a}. Negative values are not allowed in pie charts. All slice values must be >= 0.`);u.has(t)||(u.set(t,a),w.debug(`added new section: ${t}, with value: ${a}`))},"addSection"),vt=s(()=>u,"getSections"),xt=s(t=>{D=t},"setShowData"),St=s(()=>D,"getShowData"),G={getConfig:ut,clear:ft,setDiagramTitle:at,getDiagramTitle:et,setAccTitle:tt,getAccTitle:Y,setAccDescription:Q,getAccDescription:K,addSection:mt,getSections:vt,setShowData:xt,getShowData:St},wt=s((t,a)=>{j(t,a),a.setShowData(t.showData),t.sections.map(a.addSection)},"populateDb"),Ct={parse:s(async t=>{const a=await J("pie",t);w.debug(a),wt(a,G)},"parse")},Dt=s(t=>`
  .pieCircle{
    stroke: ${t.pieStrokeColor};
    stroke-width : ${t.pieStrokeWidth};
    opacity : ${t.pieOpacity};
  }
  .pieOuterCircle{
    stroke: ${t.pieOuterStrokeColor};
    stroke-width: ${t.pieOuterStrokeWidth};
    fill: none;
  }
  .pieTitleText {
    text-anchor: middle;
    font-size: ${t.pieTitleTextSize};
    fill: ${t.pieTitleTextColor};
    font-family: ${t.fontFamily};
  }
  .slice {
    font-family: ${t.fontFamily};
    fill: ${t.pieSectionTextColor};
    font-size:${t.pieSectionTextSize};
    // fill: white;
  }
  .legend text {
    fill: ${t.pieLegendTextColor};
    font-family: ${t.fontFamily};
    font-size: ${t.pieLegendTextSize};
  }
`,"getStyles"),$t=Dt,yt=s(t=>{const a=[...t.values()].reduce((r,n)=>r+n,0),$=[...t.entries()].map(([r,n])=>({label:r,value:n})).filter(r=>r.value/a*100>=1);return dt().value(r=>r.value).sort(null)($)},"createPieArcs"),Tt=s((t,a,$,y)=>{w.debug(`rendering pie chart
`+t);const r=y.db,n=it(),T=rt(r.getConfig(),n.pie),A=40,o=18,p=4,c=450,d=c,f=st(a),l=f.append("g");l.attr("transform","translate("+d/2+","+c/2+")");const{themeVariables:i}=n;let[_]=ot(i.pieOuterStrokeWidth);_??=2;const b=T.textPosition,g=Math.min(d,c)/2-A,L=M().innerRadius(0).outerRadius(g),B=M().innerRadius(g*b).outerRadius(g*b);l.append("circle").attr("cx",0).attr("cy",0).attr("r",g+_/2).attr("class","pieOuterCircle");const h=r.getSections(),I=yt(h),O=[i.pie1,i.pie2,i.pie3,i.pie4,i.pie5,i.pie6,i.pie7,i.pie8,i.pie9,i.pie10,i.pie11,i.pie12];let m=0;h.forEach(e=>{m+=e});const E=I.filter(e=>(e.data.value/m*100).toFixed(0)!=="0"),v=nt(O).domain([...h.keys()]);l.selectAll("mySlices").data(E).enter().append("path").attr("d",L).attr("fill",e=>v(e.data.label)).attr("class","pieCircle"),l.selectAll("mySlices").data(E).enter().append("text").text(e=>(e.data.value/m*100).toFixed(0)+"%").attr("transform",e=>"translate("+B.centroid(e)+")").style("text-anchor","middle").attr("class","slice");const P=l.append("text").text(r.getDiagramTitle()).attr("x",0).attr("y",-400/2).attr("class","pieTitleText"),k=[...h.entries()].map(([e,S])=>({label:e,value:S})),x=l.selectAll(".legend").data(k).enter().append("g").attr("class","legend").attr("transform",(e,S)=>{const F=o+p,V=F*k.length/2,X=12*o,Z=S*F-V;return"translate("+X+","+Z+")"});x.append("rect").attr("width",o).attr("height",o).style("fill",e=>v(e.label)).style("stroke",e=>v(e.label)),x.append("text").attr("x",o+p).attr("y",o-p).text(e=>r.getShowData()?`${e.label} [${e.value}]`:e.label);const N=Math.max(...x.selectAll("text").nodes().map(e=>e?.getBoundingClientRect().width??0)),U=d+A+o+p+N,R=P.node()?.getBoundingClientRect().width??0,q=d/2-R/2,H=d/2+R/2,W=Math.min(0,q),z=Math.max(U,H)-W;f.attr("viewBox",`${W} 0 ${z} ${c}`),lt(f,c,z,T.useMaxWidth)},"draw"),At={draw:Tt},Ot={parser:Ct,db:G,renderer:At,styles:$t};export{Ot as diagram};
