//        Ext.Loader.setConfig({ enabled: true });
//        Ext.Loader.setPath('Ext.ux', 'js/Ext/ux/');
//        Ext.require([
//        'Ext.data.TreeStore',
//        'Ext.tree.Panel',
//        'Ext.Viewport',
//        'Ext.tab.Panel',
//       
//    'Ext.ux.TabScrollerMenu'
//        ]);


$(document).ready(function () {


    $(".main_Menu li").click(function (obj) {

        switch (this.innerHTML) {
            case "商品管理":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "商品列表", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商品类目", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商品属性", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "添加商品", href: '#!/admin/Product/add.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "批量上传", href: '#!/admin/Product/batch.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]

                });
                break;
            case "订单管理":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "已确认订单", href: '#!/admin/user/Order.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "已付款订单", href: '#!/admin/user/Order.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "已发货订单", href: '#!/admin/user/Order.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "已完成订单", href: '#!/admin/user/Order.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "申请退货订单", href: '#!/admin/user/Order.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "已退货订单", href: '#!/admin/user/Order.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "报表", iconCls: 'no-node-icon', expanded: true, children: [
                        { text: "区域销售报表", href: '#!/admin/Report/regionReport.aspx', iconCls: 'no-node-icon', leaf: true },
                        { text: "销售报表", href: '#!/admin/Report/SalesReport.aspx', iconCls: 'no-node-icon', leaf: true },
                        { text: "用户访问报表", href: '#!/admin/Report/VisitorsReport.aspx', iconCls: 'no-node-icon', leaf: true }
                        ]
                    }
                    ]
                });
                break;
            case "客户管理":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "会员列表", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "添加会员", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]

                });
                break;
            case "支付与快递":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "区域管理", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "快递管理", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "支付管理", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true }
                  ]

                });
                break;
            case "供应商":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "供应商列表", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "供应商属性", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "供应商对应的产品", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "添加供应商", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true }
                  ]

                });
                break;
            case "新闻管理":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "新闻列表", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "新闻类别", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "添加新闻", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]

                });
                break;
            case "评论管理":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "评论", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "用户留言", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "用户询盘", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                  ]

                });
                break;
            case "广告管理":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "商城头部", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商城底部", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商城左侧", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商城右侧", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "友情连接", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "flash", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]

                });
                break;
            case "Seo优化":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "关键词连接", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "关键词设置", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "词库管理", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商城导航", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]

                });
                break;
            case "商城配置":
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "商城配置", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "系统帐号", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true }
                  ]

                });
                break;
            default:
                tree.setRootNode({
                    text: 'Root',
                    expanded: true,
                    children: [
                    { text: "商品列表", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商品类目", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商品属性", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "添加商品", href: '#!/admin/Product/add.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "批量上传", href: '#!/admin/Product/batch.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]

                });

        }

        tree.doLayout();

    });

});

function Request(sName) {

    /*
    get last loc. of ?
    right: find first loc. of sName
    +2
    retrieve value before next &
  
    */

    var sURL = new String(window.location);
    var sURL = document.location.href;
    var iQMark = sURL.lastIndexOf('?');
    var iLensName = sName.length;

    //retrieve loc. of sName
    var iStart = sURL.indexOf('?' + sName + '=') //limitation 1
    if (iStart == -1) {//not found at start
        iStart = sURL.indexOf('&' + sName + '=')//limitation 1
        if (iStart == -1) {//not found at end
            return 0; //not found
        }
    }

    iStart = iStart + +iLensName + 2;
    var iTemp = sURL.indexOf('&', iStart); //next pair start
    if (iTemp == -1) {//EOF
        iTemp = sURL.length;
    }
    return sURL.slice(iStart, iTemp);
    sURL = null; //destroy String
}

Ext.onReady(function () {
//    var store;

//    var stortType = unescape(Request("type"));
//    switch (stortType) {
//        case "商品管理":
//            store = proStore;
//            break;
//        case "订单管理":
//            store = OrderStore;
//            break;
//        case "客户管理":
//            store = memberStore;
//            break;
//        case "支付与快递":
//            store = PayExpressStore.getRootNode;
//            break;
//        case "供应商":
//            store = supplierStore;
//            break;
//        case "新闻管理":
//            store = newsStore;
//            break;
//        case "评论管理":
//            store = commentaryStore;
//            break;
//        case "广告管理":
//            store = advStore;
//            break;
//        case "Seo优化":
//            store = SeoStore;
//            break;
//        case "商城配置":
//            store = ShopStore;
//            break;
//        default:
//            store = proStore;

//    }



    //    //            Ext.tip.QuickTipManager.init();
        var store = Ext.create('Ext.data.TreeStore', {
            root: {
                expanded: true,
                children: [
                                        { text: "detention", id: "1", href: 'http://www.baidu.com', hrefTarget: 'main', iconCls: 'no-node-icon', leaf: true },
                                        { text: "商品管理", iconCls: 'no-node-icon', expanded: true, children: [
                                             { text: "商品列表", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                                             { text: "商品类目", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                                             { text: "商品属性", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                                             { text: "添加商品", href: '#!/admin/Product/add.aspx', iconCls: 'no-node-icon', leaf: true },
                                             { text: "批量上传", href: '#!/admin/Product/batch.aspx', iconCls: 'no-node-icon', leaf: true }

                                            //                                         { text: "homework", iconCls: 'no-node-icon', expanded: true, children: [
                                            //                                                { text: "book report1", iconCls: 'no-node-icon', leaf: true },
                                            //                                                { text: "alegrbra1", iconCls: 'no-node-icon', leaf: true }
                                            //                                              ]
                                            //                                         }
                                            ]
                                        },
                                        { text: "新闻管理", iconCls: 'no-node-icon', expanded: true, children: [
                                             { text: "新闻类别", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                                             { text: "新闻列表", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                                             ]
                                        },
                                         { text: "订单管理", iconCls: 'no-node-icon', expanded: true, children: [
                                             { text: "待支付订单", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                                             { text: "已发货订单", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                                             { text: "已完成订单", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                                             ]
                                         },
                                          { text: "客服管理", iconCls: 'no-node-icon', expanded: true, children: [
                                             { text: "客户列表", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                                             { text: "添加列表", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                                             ]
                                          },
                                          { text: "支付快递", iconCls: 'no-node-icon', expanded: true, children: [
                                             { text: "客户列表", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                                             { text: "添加列表", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                                             ]
                                          },
                            { text: "buy lottery tickets", iconCls: 'no-node-icon', leaf: true }
                                    ]
            }
        });

    //            Ext.define('Menu', {
    //                extend: 'Ext.data.Model',
    //                fields: ['text', 'id', 'leaf']
    //            });
    //            var store = Ext.create('Ext.data.TreeStore', {
    //                model: 'Menu',
    //                proxy: {
    //                    type: 'jsonp',
    //                    url: 'ExtJson.aspx',
    //                    callbackKey: 'GetExtTreeJSON'
    //                }
    //            });
    //            store.load();

    tree = Ext.create('Ext.tree.Panel', {
        region: "west",
        autoScroll: true,
        enableTabScroll: true,
        useArrows: true,
        autoHeight: true,
        split: true,
        animate: true,
        enableDD: true,
        border: false,
        containerScroll: true,
        store: store,
        lines: false,
        plugins: false,
        rootVisible: false,
        //                listeners: {
        //                    click: {
        //                        element: 'el', //bind to the underlying el property on the panel
        //                        fn: function (n,e) {

        //                       

        //                            for (i = 0; i < n.target.childNodes.length; i++) {
        //                                if (n.target.childNodes[i].className == "x-tree-elbow-plus x-tree-expander" || n.target.childNodes[i].className == "x-tree-elbow-end-plus x-tree-expander") {
        //                                    n.target.childNodes[i].click();
        //                                    return;
        //                                }


        //                                if (n.target.childNodes[i].nodeName == "A" || n.target.nodeName == "A") {

        //                                    mainPanel.add({
        //                                        id: "tab" + index,
        //                                        contentEl: 'center1',
        //                                        title: "tab" + index,
        //                                        closable: true,
        //                                        autoScroll: true
        //                                    }).show();
        ////                                    mainPanel.setActiveTab("tabl" + index);
        ////                                    mainPanel.doLayout();
        //                                    index++;
        //                                }
        //                            }




        //                        }
        //                    }
        //                },
        renderTo: "west"
    });

    tree.on('itemclick', function (view, record, item, index, e, eOpts) {

        if (!record.hasChildNodes()) {

            var tabid = "tab-" + index;

            if (mainPanel.items.containsKey(tabid)) {
                mainPanel.setActiveTab(tabid);
            }
            else {
                var iframe_html = "<iframe id='frame_" + index + "' frameborder='0' height='100%' width='100%' src='" + record.data.href.replace("#!", "") + "'/>";
                mainPanel.add({
                    id: tabid,
                    //                            contentEl: 'center1',
                    title: record.data.text,
                    closable: true,
                    html: iframe_html,
                    //loader: { url: record.data.href.replace("#!",""), loadMask: 'loading...', autoLoad: true, scripts: true },
                    autoScroll: true
                }).show();
                //                        mainPanel.setActiveTab(tabid);
                //                        mainPanel.doLayout();
            }
            return;
        }


        if (record.isExpanded()) {
            record.collapse();
        }
        else {
            record.expand();
        }
    });


    viewport = Ext.create('Ext.container.Viewport', {
        layout: 'border',
        items: [
        // create instance immediately
            Ext.create('Ext.Component', {
                region: 'north',
                height: 132, // give north and south regions a height
                contentEl: 'topInfo'
                //                autoEl: {
                //                    tag: 'div',
                //                    html: '<p>north - generally for menus, toolbars and/or advertisements</p>'
                //                }
            }), {
                // lazily created panel (xtype:'panel' is default)
                region: 'south',
                contentEl: 'south',
                split: true,
                height: 100,
                minSize: 100,
                maxSize: 200,
                collapsible: true,
                collapsed: true,
                title: 'Soddsssssssssssuth',
                margins: '0 0 0 0'
            }, {
                region: 'west',
                //                stateId: 'navigation-panel',
                //                id: 'west-panel', // see Ext.getCmp() below
                title: "功能菜单",
                split: true,
                width: 200,
                minWidth: 175,
                maxWidth: 400,
                collapsible: true,
                animCollapse: true,
                margins: '0 0 0 5',
                //                layout: 'accordion',
                items: [tree]
            },

        // in this instance the TabPanel is not wrapped by another panel
        // since no title is needed, this Panel is added directly
        // as a Container center
            mainPanel = Ext.create('Ext.tab.Panel', {
                region: 'center', // a center region is ALWAYS required for border layout
                deferredRender: false,
                frame: true,
                // activeTab: 0,     // first tab initially active
                xtype: 'tabpanel'
                //                plugins: [{
                //                    ptype: 'tabscrollermenu',
                //                    maxText: 15,
                //                    pageSize: 5
                //                }],

                //                items: [
                //                {
                //                    contentEl: 'center2',
                //                    title: '首页',
                //                    url: '/admin/product/list.aspx',
                //                    autoScroll: true
                //                }, {
                //                    contentEl: 'center1',
                //                    title: 'Close Me',
                //                    closable: true,
                //                    autoScroll: true
                //                }]
            }


            )]


    });


});
