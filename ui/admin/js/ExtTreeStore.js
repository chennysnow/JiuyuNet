Ext.require(['Ext.data.*']);

Ext.onReady(function () {

    /// <summary>
    /// 商品管理
    /// </summary>
    proStore = {
       text: 'Root',
            expanded: true,
            children: [
                    { text: "商品列表", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商品类目", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商品属性", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "添加商品", href: '#!/admin/Product/add.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "批量上传", href: '#!/admin/Product/batch.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]
        
    };
    /// <summary>
    /// 供应商管理
    /// </summary>
    supplierStore = {
       text: 'Root',
            expanded: true,
            children: [
                    { text: "供应商列表", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "供应商属性", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "供应商对应的产品", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "添加供应商", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true }
                  ]
        
    };

    /// <summary>
    /// 订单管理
    /// </summary>
    OrderStore = {
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
    };

    /// <summary>
    /// 支付方式与快递
    /// </summary>
    PayExpressStore = {
      text: 'Root',
            expanded: true,
            children: [
                    { text: "区域管理", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "快递管理", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "支付管理", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true }
                  ]
        
    };

    /// <summary>
    /// 客户管理
    /// </summary>
    memberStore ={
      text: 'Root',
            expanded: true,
            children: [
                    { text: "会员列表", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "添加会员", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]
        
    };
    /// <summary>
    /// 评论管理
    /// </summary>
    commentaryStore = {
       text: 'Root',
            expanded: true,
            children: [
                    { text: "评论", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "用户留言", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "用户询盘", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                  ]
        
    };

    /// <summary>
    /// 新闻管理
    /// </summary>
    newsStore = {
        text: 'Root',
            expanded: true,
            children: [
                    { text: "新闻列表", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "新闻类别", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "添加新闻", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]
        
    };
    /// <summary>
    /// 广告管理
    /// </summary>
    advStore = {
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
        
    };

    /// <summary>
    /// Seo管理
    /// </summary>
    SeoStore = {
      text: 'Root',
            expanded: true,
            children: [
                    { text: "关键词连接", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "关键词设置", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "词库管理", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "商城导航", href: '#!/admin/product/list.aspx', iconCls: 'no-node-icon', leaf: true }
                    ]
        
    };

    /// <summary>
    /// 商城管理
    /// </summary>
    ShopStore =  {
       text: 'Root',
            expanded: true,
            children: [
                    { text: "商城配置", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true },
                    { text: "系统帐号", href: '#!/admin/Product/type.aspx', iconCls: 'no-node-icon', leaf: true }
                  ]
        
    };



});