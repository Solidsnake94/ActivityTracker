import React from 'react';
import ReactShallowRender from 'react-test-renderer/shallow';

import DashboardNavTop from '../../components/DashboardNavTop';

test('should render dashboardnavtop correctly', () => {
    const renderer = new ReactShallowRender();

    renderer.render(< DashboardNavTop />);
    expect(renderer.getRenderOutput()).toMatchSnapshot();
})